using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class UserDto
    {
        //karışık model propertileri içerir
        public int ID { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string NameSurname { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen Geçerli Bir Telefon Numarası Giriniz!")]

        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen Gecerli Email Adresi Giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen İl Seçiniz")]
        public string Country { get; set; }
        public string Towner { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string StatusMessage { get; set; }
    }
}
