using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            IsActive = true;
            IsCargo = false;
            IsHandDeliver = true;
        }
        public int ShortName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsCargo { get; set; }
        public bool IsHandDeliver { get; set; }

        //fk
        public int UserID { get; set; }
        public int TownID { get; set; }


        //relation Property
        public virtual List<ProductPicture> ProductPictures { get; set; }
        public virtual User User { get; set; }
        public virtual Town Town { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }

        public virtual Transfer Transfer { get; set; }
    }
}
