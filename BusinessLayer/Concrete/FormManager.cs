using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.FormVM;
using DataAccessLayer.Abstract;
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
    }
}
