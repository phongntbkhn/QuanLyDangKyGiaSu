using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(x => x.CId);
            builder.Property(x => x.CId).UseIdentityColumn();
            builder.Property(x => x.Image).HasMaxLength(200);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");          
            builder.HasOne(x => x.Teacher).WithMany(x => x.Courses).HasForeignKey(x => x.TId);

        }
    }
}
