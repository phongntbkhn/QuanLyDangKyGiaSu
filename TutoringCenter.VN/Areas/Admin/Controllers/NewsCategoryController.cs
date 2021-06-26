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
    public class NewsCategoryController : Controller
    {
        private readonly IDataRepository<NewsCategory> _context;
        public NewsCategoryController(IDataRepository<NewsCategory> context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var newsCategories = _context.GetAll();
            return View(newsCategories);
        }
        public IActionResult Create()
        {
            ViewBag.notification = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(newsCategory);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            ViewBag.notification = "";
            var newsCategory = await _context.Get(id);
            return View(newsCategory);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdateToNew(NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                newsCategory.UpdateAt = DateTime.Now;
                var newsCategoryDb = await _context.Get(newsCategory.NCId);
               await _context.Update(newsCategoryDb, newsCategory);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var newsCategory = await _context.Get(id);
            return View(newsCategory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                await _context.Delete(newsCategory);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}