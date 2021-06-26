using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string TenHocSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Lop { get; set; }
        public string TenPhuHuynh { get; set; }
        public string SdtPhuHuynh { get; set; }
        /// <summary>
        /// 1. Dang ky, 2. Xac nhan
        /// </summary>
        public int Status { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string NoiOHienTai { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public int UId { get; set; }
    }
}
