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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasOne<Product>(s => s.Product)
                 .WithMany(a => a.ProductCategories)
                 .HasForeignKey(b => b.ProductID);

            builder.HasOne<Category>(s => s.Category)
                .WithMany(a => a.ProductCategories)
                .HasForeignKey(b => b.ProductID);
        }
    }
}
