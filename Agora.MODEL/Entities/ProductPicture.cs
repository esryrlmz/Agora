using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class ProductPicture:BaseEntity
    {
        public string PictureUrl { get; set; }

        //FK
        public int ProductID { get; set; }

        //relation Property
        public virtual Product Product { get; set; }
    }
}
