using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Category:BaseEntity
    {
      public string CategoryName { get; set; }
      public int? ParentCategoryId { get; set; }

      //relation property
      public virtual List<Category> SubCategory { get; set; }
      public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
