using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agora.MAP.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.Property(x => x.NameSurname).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar(11)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)");

            //1-1 ilişkide hasforeign key kısmına tablo adını vermelisin
            builder.HasOne<User>(s => s.User)
                 .WithOne(a => a.UserDetail)
                 .HasForeignKey<UserDetail>(b => b.UserID);
        }
    }
}
