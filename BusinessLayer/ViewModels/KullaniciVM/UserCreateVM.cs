using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels.KullaniciVM
{
    public class UserCreateVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }
}
