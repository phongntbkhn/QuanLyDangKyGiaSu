using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TutoringCenter.VN.Components
{
    public class RoleMenuViewComponent : ViewComponent
    {
        public RoleMenuViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}