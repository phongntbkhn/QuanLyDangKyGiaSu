using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IDataRepository<AboutUs> _aboutUs;
        public AboutUsController(IDataRepository<AboutUs> aboutUs) {
            _aboutUs = aboutUs;
        }
        public IActionResult Index()
        {
            ViewBag.aboutUs = _aboutUs.GetAll();
            return View();
        }
    }
}