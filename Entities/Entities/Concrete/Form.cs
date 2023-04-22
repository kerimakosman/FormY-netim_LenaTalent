using Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete
{
    public class Form:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
