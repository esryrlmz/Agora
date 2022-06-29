using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class ProductPictureMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(300)")]
        public string PictureUrl { get; set; }
    }
}
