using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities.MetaDataTypes
{
    public class CategoryMetaData
    {
        [Required(ErrorMessage = "Zorunlu alan"), Column(TypeName = "nvarchar(200)")]
        public string CategoryName { get; set; }

        [ForeignKey("ParentCategoryId")]
        public int? ParentCategoryId { get; set; }

        //relation Property
        public virtual List<Category> SubCategory { get; set; }
    }
}
