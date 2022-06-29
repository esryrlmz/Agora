using Agora.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.MAP.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        // fk olan tabloda ilişkiyi tanımla
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ShortName).HasColumnType("varchar(80)").IsRequired();

            builder.HasOne<Town>(s => s.Town)
                .WithMany(a => a.Products)
                .HasForeignKey(b => b.TownID);

            builder.HasOne<User>(s => s.User)
               .WithMany(a => a.Products)
               .HasForeignKey(b => b.TownID);
        }
    }
}
