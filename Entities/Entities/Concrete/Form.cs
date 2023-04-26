using Entities.Entities.Abstract;
using Entities.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete
{
    public class Form : BaseEntity
    {
        public Form()
        {
            FormMessages= new HashSet<FormMessage>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Replies { get; set; }
        public int Views { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<FormMessage> FormMessages { get; set; }
    }
}
