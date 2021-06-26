using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(x => x.NId);
            builder.Property(x => x.NId).UseIdentityColumn();
            builder.Property(x => x.Tags).HasMaxLength(100);
            builder.Property(x => x.Image).HasMaxLength(200);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.User).WithMany(x => x.News).HasForeignKey(x => x.UId);
            builder.HasOne(x => x.NewsCategory).WithMany(x => x.News).HasForeignKey(x => x.NCId);
        }
    }
}
