using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Comment:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Interpretation { get; set; }

        public int ProductID { get; set; }

        //Relation Property

        public Product Product { get; set; }

    }
}
