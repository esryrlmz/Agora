using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Category:BaseEntity
    {
      public string CategoryName { get; set; }
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
      
        //RELATİON pROPERTY
        public virtual ICollection<Category> Childs { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
