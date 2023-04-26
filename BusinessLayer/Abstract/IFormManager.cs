using BusinessLayer.ViewModels.FormVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFormManager
    {
        Task<IList<FormListVM>> FormGetList();
        Task CreateForm(FormCreateVM form);
        Task<FormMessageListVM> GetFormMessage(int formId);
        Task NewFormMessage(FormMessagePostVM formMessagePost);
    }
}
