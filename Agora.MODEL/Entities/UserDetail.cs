
namespace Agora.MODEL.Entities
{
    public class UserDetail:BaseEntity
    {
        public string NameSurname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        //FK
        public int UserID { get; set; }


        //relation Property

        public virtual User User { get; set; }
    }
}
