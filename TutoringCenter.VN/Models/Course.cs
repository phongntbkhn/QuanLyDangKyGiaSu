using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class Course
    {
        [Key]
        public int CId { get; set; }
        public int TId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string LearningTime { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Schedule { get; set; }
        public string Image { get; set; }
        public int? IdKhoi { get; set; }
        public int? IdLop { get; set; }

        public DateTime? CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public virtual Teacher Teacher { get; set; }

    }
}
