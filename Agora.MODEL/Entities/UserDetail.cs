
using Agora.MODEL.Enums;

namespace Agora.MODEL.Entities
{
    public class UserDetail:BaseEntity
    {
        public UserDetail()
        {
            Gender = Gender.Female;
        }
        public string NameSurname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Country { get; set; }
        public string Towner { get; set; }
        public Gender Gender { get; set; }
        //FK
        public int UserID { get; set; }


        //relation Property

        public virtual User User { get; set; }
    }
}
