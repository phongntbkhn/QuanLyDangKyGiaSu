using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class CourseStudent
    {
        [Key]
        public int Id { get; set; }
        public int CId { get; set; }
        public int StudentId { get; set; }
        public int? IsDanhGia { get; set; }
        public int? Diem { get; set; }
    }
}
