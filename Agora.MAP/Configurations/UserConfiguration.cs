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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName).HasColumnType("varchar(20)").IsRequired().HasMaxLength(10);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.UserName).IsUnique();

        }
    }
}
