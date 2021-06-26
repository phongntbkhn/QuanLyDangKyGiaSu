using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class User
    {
        public int UId { get; set; }
        public string Username { get; set; }
        public string EncryptPassword { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public int Role { get; set; }
        public int RoleHome { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public ICollection<AboutUs> AboutUs { get; set; }
        public ICollection<CommonQuestion> CommonQuestions { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<News> News { get; set; }
    }
}
