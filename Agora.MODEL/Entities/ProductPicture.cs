using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class ProductPicture:BaseEntity
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public string PictureUrl { get; set; }
        //FK
        public int ProductID { get; set; }

        //relation Property
        public virtual Product Product { get; set; }
    }
}
