using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class Transfer:BaseEntity
    {
        public Transfer()
        {
            ProductStatus = ProductStatus.Ownerless;
        }
        public string Adress { get; set; }
        public string Description { get; set; }
        public DateTime TransferDate { get; set; }//transferdate transfer edildiğinde girilecek ve status guncellenecek
        public ProductStatus ProductStatus { get; set; }

        //fk: sahiplenen kişi
        public int? UserID { get; set; }
        public int ProductID { get; set; }

        //Relation Property

        public User User { get; set; }
        public Product Product { get; set; }
        public Cargo Cargo { get; set; }
    }
}
