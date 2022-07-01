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
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.Property(x => x.Adress).HasColumnType("varchar(max)").IsRequired();

            builder.HasOne<Product>(s => s.Product)
                .WithOne(a => a.Transfer)
                .HasForeignKey<Transfer>(b => b.ProductID);

            builder.HasOne<User>(s => s.User)
              .WithMany(a => a.Transfers)
              .HasForeignKey(b => b.UserID);
        }
    }
}
