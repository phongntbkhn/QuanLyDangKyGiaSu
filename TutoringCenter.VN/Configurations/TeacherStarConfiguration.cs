using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class TeacherStarConfiguration : IEntityTypeConfiguration<TeacherStar>
    {
        public void Configure(EntityTypeBuilder<TeacherStar> builder)
        {
            builder.ToTable("TeacherStar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
