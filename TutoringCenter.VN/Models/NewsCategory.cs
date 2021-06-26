using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Utils;

namespace TutoringCenter.VN.Models
{
    public class NewsCategory
    {
        public int NCId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public ICollection<News> News { get; set; }
        public string GetPath()
        {
            return $"{Name.NonUnicodeString().Replace(" ", "-")}-{NCId}";
        }
    }
}
