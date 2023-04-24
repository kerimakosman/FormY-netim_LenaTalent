using Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete.Identity
{
    public class Role:BaseEntity
    {
        public Role()
        {
            UserRoles=new HashSet<UserRole>();
        }
        public string RoleName { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }

    }
}
