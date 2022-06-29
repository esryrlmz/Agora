using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class CargoMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(150)")]
        public string CargoTrackingNumber { get; set; }
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(150)")]
        public string CargoFirm { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
    }
}
