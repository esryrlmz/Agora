using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class ProductCategory:BaseEntity
    {
        //fk
        public int CategoryID { get; set; }
        public int ProductID { get; set; }

        //relationProperty

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }
    }
}
