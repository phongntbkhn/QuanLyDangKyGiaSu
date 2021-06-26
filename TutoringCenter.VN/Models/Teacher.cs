using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class Teacher
    {
        [Key]
        public int TId { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public string Cv { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string CMND { get; set; }
        public string QueQuan { get; set; }
        public string NoiOHienTai { get; set; }
        public string KhuVucGiangDay { get; set; }

        /// <summary>
        /// 1. Dang ky, 2. Xac nhan
        /// </summary>
        public int Status { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public int UId { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
