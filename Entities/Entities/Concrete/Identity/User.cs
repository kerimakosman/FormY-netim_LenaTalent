using Entities.Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete.Identity
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            Forms=new HashSet<Form>();
            FormMessages= new HashSet<FormMessage>();
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Form> Forms { get; set; }
        public ICollection<FormMessage> FormMessages { get; set; }

    }
}
