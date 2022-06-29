using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Role = Role.Uye;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }


        //relation Property

        public virtual UserDetail UserDetail { get; set; }
        public virtual List<Product> Products { get; set; }

        public virtual List<Transfer> Transfers { get; set; }
    }
}
