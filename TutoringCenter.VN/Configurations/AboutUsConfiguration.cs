using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.ToTable("AboutUs");
            builder.HasKey(x => x.AUId);
            builder.Property(x => x.AUId).UseIdentityColumn();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.User).WithMany(x => x.AboutUs).HasForeignKey(x => x.UId);
        }
    }
}
