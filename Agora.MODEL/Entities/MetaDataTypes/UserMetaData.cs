using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class UserMetaData
    {

        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(50)")]

        public string UserName { get; set; }

        [Column(TypeName = "char(6)")]
        [MaxLength(5, ErrorMessage = "en fazla 6 karakter")]
        [MinLength(5, ErrorMessage = "en az 6 karakter")]
        public string Password { get; set; }
    }
}
