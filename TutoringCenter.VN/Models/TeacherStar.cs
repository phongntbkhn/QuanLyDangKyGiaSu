using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class TeacherStar
    {
        [Key]
        public int Id { get; set; }
        public int TId { get; set; }
        public int? Diem { get; set; }
        public int? StudentId { get; set; }
    }
}
