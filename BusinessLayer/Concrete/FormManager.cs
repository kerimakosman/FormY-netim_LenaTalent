using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.FormVM;
using DataAccessLayer.Abstract;
using Entities.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FormManager : IFormManager
    {
        private readonly IFormRepository _formRepository;
        private readonly IFormMessageRepository _formMessageRepository;
        private readonly IUserRepository _userRepository;

        public FormManager(IFormRepository formRepository, IFormMessageRepository formMessageRepository, IUserRepository userRepository)
        {
            _formRepository = formRepository;
            _formMessageRepository = formMessageRepository;
            _userRepository = userRepository;
        }

        public async Task<IList<FormListVM>> FormGetList()
        {
           return await (from us in _userRepository.Table
                  join f in _formRepository.Table on us.Id equals f.UserId
                  select new FormListVM
                  {
                      FormId= f.Id,
                      FormName= f.Name,
                      FormDescription= f.Description,
                      UserId=us.Id,
                      UserName= us.UserName,
                      CreateDate=f.CreateDate
                  }).OrderByDescending(f => f.CreateDate).ToListAsync();
        }
        public async Task CreateForm(FormCreateVM form)
        {
            var user=await _userRepository.GetFirstAsync(u=>u.UserName== form.UserName);
            user.Forms.Add(new()
            {
                Name=form.FormName,
                Description=form.FormDescription
            });
            //await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task<FormMessageListVM> GetFormMessage(int formId)
        {
             var formMesaj=await _formMessageRepository.Table
                                .Include(fm=>fm.User)
                                .Where(fm=>fm.FormId==formId)
                                .Select(fm=>new MessageList()
                                {
                                    UserName=fm.User.UserName,
                                    FormMessage=fm.Message,
                                    CreateMessage=fm.CreateDate
                                }).ToListAsync();

            var form = await _formRepository.Table
                            .Include(f => f.User)
                            .FirstOrDefaultAsync(f => f.Id == formId);
            return new()
            {
                FormId=form.Id,
                FormName=form.Name,
                FormDescription=form.Description,
                FormDateTime=form.CreateDate,
                UserId=form.UserId,
                UserName=form.User.UserName,
                MessageList=formMesaj.OrderBy(mesajlist=> mesajlist.CreateMessage).ToList()
            };
        }

        public async Task NewFormMessage(FormMessagePostVM formMessagePost)
        {
            var user = await _userRepository.GetFirstAsync(u => u.UserName == formMessagePost.UserName);
            user.FormMessages.Add(new()
            {
                Message= formMessagePost.FormMessage,
                FormId=formMessagePost.FormId
            });
            await _userRepository.SaveAsync();
        }
    }
}
