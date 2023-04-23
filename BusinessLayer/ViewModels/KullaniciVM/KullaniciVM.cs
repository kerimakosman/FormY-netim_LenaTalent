using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels.KullaniciVM
{
    public class KullaniciVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanici Adi Boş olamaz")]
        public string KullaniciAdi { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre boş olamaz")]
        public string Sifre { get; set; }
    }
}
