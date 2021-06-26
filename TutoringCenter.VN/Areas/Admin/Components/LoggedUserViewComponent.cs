using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringCenter.VN.Areas.Admin.Components
{
    public class LoggedUserViewComponent : ViewComponent
    {
        public LoggedUserViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
