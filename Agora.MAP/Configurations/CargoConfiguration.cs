using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Agora.MAP.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasIndex(x => x.CargoTrackingNumber).IsUnique();
            builder.Property(x => x.CargoTrackingNumber).HasColumnType("varchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.CargoFirm).HasColumnType("varchar(30)").IsRequired();




            builder.HasOne<Transfer> (s=> s.Transfer)
                 .WithOne(a =>a.Cargo )
                 .HasForeignKey<Cargo>(b => b.TranserID);

        }
    }
}
