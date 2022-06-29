using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Agora.MAP.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasOne<City>(s => s.City)
                .WithMany(a => a.Towns)
                .HasForeignKey(b => b.CityID);
        }
    }
}
