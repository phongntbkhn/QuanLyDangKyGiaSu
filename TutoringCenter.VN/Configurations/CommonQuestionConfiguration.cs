using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class CommonQuestionConfiguration : IEntityTypeConfiguration<CommonQuestion>
    {
        public void Configure(EntityTypeBuilder<CommonQuestion> builder)
        {
            builder.ToTable("CommonQuestion");
            builder.HasKey(x => x.CQId);
            builder.Property(x => x.CQId).UseIdentityColumn();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.User).WithMany(x => x.CommonQuestions).HasForeignKey(x => x.UId);
        }
    }
}
