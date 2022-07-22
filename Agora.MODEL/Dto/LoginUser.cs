using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class LoginUser
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserNameOrMail { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
    }
}
