using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.SId);
            builder.Property(x => x.TenHocSinh).HasMaxLength(100);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.Lop).HasMaxLength(20);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.TenPhuHuynh).HasMaxLength(100);
            builder.Property(x => x.SdtPhuHuynh).HasMaxLength(20);
            builder.Property(x => x.NoiOHienTai).HasMaxLength(300);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
