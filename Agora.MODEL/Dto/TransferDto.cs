using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class TransferDto
    {
        public int TransferID { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public DateTime TransferDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public int ProductUserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUserName { get; set; }
        public string ProductTown { get; set; }
        public bool IsCargo { get; set; }
        public bool IsHandDeliver { get; set; }
        public string ProductCity { get; set; }
        public int TransferUserId { get; set; }
        public string TransferUserName { get; set; }
    }
}
