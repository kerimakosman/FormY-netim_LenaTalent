using BusinessLayer.ViewModels.KullaniciVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAccountManager
    {
        Task<bool> KullaniciContex(KullaniciVM user);
        Task<bool> CreateUser(UserCreateVM createUser);
    }
}
