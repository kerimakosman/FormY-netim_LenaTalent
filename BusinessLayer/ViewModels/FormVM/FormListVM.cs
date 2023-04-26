using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels.FormVM
{
    public class FormListVM
    {
        public int FormId { get; set; }
        public string FormName{ get; set; }
        public string FormDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public int Replies { get; set; }
        public int Views { get; set; }
        //public string Ad { get; set; }
        //public string Soyad { get; set; }
        //public byte Yas { get; set; }
        public string UserName { get; set; }
    }
}
