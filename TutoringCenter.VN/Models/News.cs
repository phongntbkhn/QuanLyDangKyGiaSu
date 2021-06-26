using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Utils;

namespace TutoringCenter.VN.Models
{
    public class News
    {
        public int NId { get; set; }
        public int NCId { get; set; }
        public int UId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Image { get; set; }

        public DateTime? CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; } = DateTime.Now;

        public virtual NewsCategory NewsCategory { get; set; }

        public virtual User User { get; set; }

        public string GetPath()
        {
            return $"{Title.NonUnicodeString().Replace(" ", "-")}-{NId}";
        }

        public string GetDay()
        {
            if (CreateAt != null)
            {
                return ((DateTime)CreateAt).ToString("dd");
            }
            else
            {
                return "--";
            }
        }

        public string GetMonth()
        {
            if (CreateAt != null)
            {
                return ((DateTime)CreateAt).ToString("MM");
            }
            else
            {
                return "--";
            }
        }
    }
}
