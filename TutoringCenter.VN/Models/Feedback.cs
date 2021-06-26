using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class Feedback
    {
        public int FId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int? ReplyByUserId { get; set; }
        public int? CoursesCId { get; set; }

        public DateTime? CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Course Courses { get; internal set; }
    }
}
