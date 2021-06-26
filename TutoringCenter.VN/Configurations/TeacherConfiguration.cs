using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasKey(x => x.TId);
            builder.Property(x => x.TId).UseIdentityColumn();
            builder.Property(x => x.DisplayName).HasMaxLength(100);
            builder.Property(x => x.Avatar).HasMaxLength(200);
            builder.Property(x => x.Cv).HasMaxLength(200);
            builder.Property(x => x.SoDienThoai).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.CMND).HasMaxLength(20);
            builder.Property(x => x.QueQuan).HasMaxLength(300);
            builder.Property(x => x.NoiOHienTai).HasMaxLength(200);
            builder.Property(x => x.KhuVucGiangDay).HasMaxLength(200);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
