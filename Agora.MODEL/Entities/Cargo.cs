using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Cargo:BaseEntity
    {
        public string CargoTrackingNumber { get; set; }
        public string CargoFirm { get; set; }
        public string Description { get; set; }

        //fk
        public int TranserID { get; set; }

        // relationProperty

        public Transfer Transfer { get; set; }
    }
}
