using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");
            builder.HasKey(x => x.FId);
            builder.Property(x => x.FId).UseIdentityColumn();
            builder.Property(x => x.Fullname).HasMaxLength(200);
            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.User).WithMany(x => x.Feedbacks).HasForeignKey(x => x.ReplyByUserId);

        }
    }
}
