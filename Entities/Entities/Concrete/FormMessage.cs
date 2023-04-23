using Entities.Entities.Abstract;
using Entities.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete
{
    public class FormMessage:BaseEntity
    {
        public string Message { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}
