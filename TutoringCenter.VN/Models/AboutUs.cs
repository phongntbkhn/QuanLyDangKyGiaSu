using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models
{
    public class AboutUs
    {
        public int AUId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UId { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
