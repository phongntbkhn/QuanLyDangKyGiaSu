using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Utils
{
    public class RoleMaps
    {
        public RoleMaps(int code, string name)
        {
            this.Role = code;
            this.Name = name;
        }
        public int Role { get; set; }
        public string Name { get; set; }

        public static RoleMaps[] GetAll()
        {
            return new[]{
                new RoleMaps(0,"Quản trị hệ thống"),
                new RoleMaps(1,"Quản trị nội dung"),
                new RoleMaps(2,"Quản trị khóa học"),
                new RoleMaps(3,"Không cấp quyền")
            };
        }

        public static SelectList GetSelectList()
        {
            return new SelectList(GetAll(), "Role", "Name");
        }

        public static string GetRoleName(int code)
        {
            foreach (RoleMaps roleMaps in GetAll())
            {
                if (roleMaps.Role == code)
                    return roleMaps.Name;
            }
            return GetAll().Last().Name;
        }
    }
}
