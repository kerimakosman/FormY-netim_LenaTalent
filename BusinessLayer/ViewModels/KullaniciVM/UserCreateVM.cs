using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels.KullaniciVM
{
    public class UserCreateVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "İsim Boş zorunlu alan")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyadı Boş zorunlu alan")]
        public string SurName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanıcı Adı zorunlu alan")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="Kullanıcı Adı 3 ile 10 karakter arasında olmalıdır")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Doğum Tarihi zorunlu alan")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cinsiyet zorunlu alan")]
        public Gender Gender { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre zorunlu alan")]
        [MinLength(3, ErrorMessage = "Şifre en az 3 karakter olmalıdır")]
        [MaxLength(50,ErrorMessage ="Şifre en fazla 50 karakter olabilir")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre zorunlu alan")]
        [Compare("Password", ErrorMessage ="Şifreler Aynı değil")]
        public string RePassword { get; set; }
    }
}
