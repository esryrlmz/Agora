using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class City: BaseEntity
    {
        public int CityName { get; set; }

        //relation Property

        public virtual List<Town> Towns { get; set; }
    }
}
