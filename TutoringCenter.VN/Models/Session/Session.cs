using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Models.Session
{
    public class Session
    {
        public string Id { get;set;}
        public string UserName { get;set;}
        public string RoleHome { get;set;}
        public string idPerson { get;set;}

        public string GetRole()
        {
            if (RoleHome == "1")
            {
                return "Admin";
            }
            else if(RoleHome == "2")
            {
                return "Gia sư";
            }
            else if(RoleHome == "3")
            {
                return "Phụ huynh";
            }
            else if (RoleHome == "4")
            {
                return "Học sinh";
            }
            else
            {
                return "";
            }
        }
    }
}
