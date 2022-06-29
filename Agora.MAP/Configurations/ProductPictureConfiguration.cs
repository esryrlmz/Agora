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
    public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.Property(x => x.PictureUrl).HasColumnType("varchar(300)").IsRequired();
            builder.HasIndex(x => x.PictureUrl).IsUnique();

            builder.HasOne<Product>(s => s.Product)
               .WithMany(a => a.ProductPictures)
               .HasForeignKey(b => b.ProductID);
        }
    }
}
