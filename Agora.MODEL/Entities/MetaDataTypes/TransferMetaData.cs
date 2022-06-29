using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class TransferMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"),Column(TypeName = "nvarchar(max)")]
        public string Adress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Xcoordinate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Ycoordinate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

    }
}
