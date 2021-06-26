using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
    {
        builder.ToTable("NewsCategory");
        builder.HasKey(x => x.NCId);
        builder.Property(x => x.NCId).UseIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(200);
        builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
