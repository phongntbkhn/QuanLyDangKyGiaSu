using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Configurations;
using TutoringCenter.VN.Models;

namespace TutoringCenter.VN.EF
{
    public class TutoringCenterDbContext : DbContext
    {
        public TutoringCenterDbContext(DbContextOptions<TutoringCenterDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AboutUsConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CommonQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new CourseStudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherStarConfiguration());
        }
        public virtual DbSet<AboutUs> Abouts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<News> TheNews { get; set; }
        public virtual DbSet<CommonQuestion> CommonQuestions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<CourseStudent> CourseStudents { get; set; }
        public virtual DbSet<TeacherStar> TeacherStars { get; set; }

    }
}
