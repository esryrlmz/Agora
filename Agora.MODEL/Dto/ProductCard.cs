using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class ProductCard
    {
        public string image { get; set; }
        public string ProductName { get; set; }
        public int CommentCount { get; set; }
        public string CreatedDate { get; set; }

        public ProductStatus ProductStatus { get; set; }
    }
}
