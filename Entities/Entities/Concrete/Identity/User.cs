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
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public byte Age { get; set; }
        public Sex Sex{ get; set; }
        public string Password { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }

    }
}
