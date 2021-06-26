using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "0,1")]
    public class AboutUsController : Controller
    {
        private readonly IDataRepository<AboutUs> _context;
        public AboutUsController(IDataRepository<AboutUs> context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var aboutUsList = _context.GetAll();
            return View(aboutUsList);
        }
        public IActionResult Create()
        {
            ViewBag.notification = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aboutUs.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                await _context.Add(aboutUs);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            ViewBag.notification = "";
            var aboutUs = await _context.Get(id);
            return View(aboutUs);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aboutUs.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                aboutUs.UpdateAt = DateTime.Now;
                var aboutUsDb = await _context.Get(aboutUs.AUId);
                await _context.Update(aboutUsDb, aboutUs);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var aboutUs = await _context.Get(id);
            return View(aboutUs);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                await _context.Delete(aboutUs);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}