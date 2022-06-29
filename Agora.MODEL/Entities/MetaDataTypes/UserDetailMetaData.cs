using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class UserDetailMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(150)")]
        public string NameSurname { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen Geçerli Mail Adresi Giriniz")]
        public string Email { get; set; }
    }
}
