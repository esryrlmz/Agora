using Agora.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class ProductDto
    {
        public ProductDto()
        {
            SubCategoryID = 0;
        }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsCargo { get; set; }
        public bool IsHandDeliver { get; set; }
        public int UserID { get; set; }


        public List<ProductPicture> Pictures { get; set; }

    }
}
