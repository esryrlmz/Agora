using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MODEL.Dto
{
    public class UserDto
    {
        //karışık model propertileri içerir
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Country { get; set; }
        public string Towner { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
    }
}
