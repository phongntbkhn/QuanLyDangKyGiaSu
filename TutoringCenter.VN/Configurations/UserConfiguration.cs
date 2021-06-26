using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UId);
            builder.Property(x => x.UId).UseIdentityColumn();
            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.DisplayName).HasMaxLength(100);
            builder.Property(x => x.EncryptPassword).HasMaxLength(500);
            builder.Property(x => x.Avatar).HasMaxLength(200);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
