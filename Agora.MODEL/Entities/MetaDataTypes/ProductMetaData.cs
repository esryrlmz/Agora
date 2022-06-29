using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class ProductMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(80)")]
        public int ShortName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        
    }
}
