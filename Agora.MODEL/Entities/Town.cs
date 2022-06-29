using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Town:BaseEntity
    {
        public string TownName { get; set; }

        //fk
        public int CityID { get; set; }

        //relation property
        public virtual City City { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
