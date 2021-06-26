using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Utils;

namespace TutoringCenter.VN.Models
{
    public class CommonQuestion
    {
        public int CQId { get; set; }
        public string  Title { get; set; }
        public string Content { get; set; }
        public int UId { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public virtual User User { get; set; }
        public string GetPath()
        {
            return $"{Title.NonUnicodeString().Replace(" ", "-")}-{CQId}";
        }
    }
}
