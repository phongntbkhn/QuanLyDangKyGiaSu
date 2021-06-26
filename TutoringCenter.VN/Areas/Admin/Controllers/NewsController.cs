using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "0,1")]
    public class NewsController : Controller
    {
        private readonly IDataRepository<News> _context;
        private readonly IDataRepository<NewsCategory> _newscategory;
        public NewsController(IDataRepository<News> context, IDataRepository<NewsCategory> newscategory)
        {
            _context = context;
            _newscategory = newscategory;
        }
        public IActionResult Index(string id)
        {
            IEnumerable<News> news;
            if (id != null)
            {
                NewsManager newsManager = (NewsManager)_context;
                news = newsManager.GetAll(long.Parse(id));
            }
            else
            {
                news = _context.GetAll();
            }
            return View(news);
        }
        public IActionResult Create()
        {
            ViewBag.notification = "";
            ViewBag.newsCategories = new SelectList(_newscategory.GetAll(), "NCId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                // contentProcessing(news.nContent);
                await _context.Add(news);
                return RedirectToAction(nameof(Index), new { id = news.NCId.ToString() });
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpPost]
        public IActionResult ImageUpload(IFormFile upload)
        {
            var filename = DateTime.Now.ToString("yyyyMMddHHmmss_") + upload.FileName;
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
            if (!Directory.Exists(pathFile))
            {
                Directory.CreateDirectory(pathFile);
            }
            pathFile = Path.Combine(pathFile, filename);
            Console.WriteLine(pathFile);
            var stream = new FileStream(pathFile, FileMode.CreateNew);
            upload.CopyToAsync(stream);
            return new JsonResult(new { path = "/Uploads/" + filename });
        }


        public async Task<IActionResult> Update(long id)
        {
            ViewBag.notification = "";
            ViewBag.newsCategories = new SelectList(_newscategory.GetAll(), "NCId", "Name");
            var news = await _context.Get(id);
            return View(news);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdateNews(News news)
        {
            if (ModelState.IsValid)
            {
                news.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var newsDb = await _context.Get(news.NId);
                await _context.Update(newsDb, news);
                return RedirectToAction(nameof(Index), new { id = news.NCId.ToString() });
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var news = await _context.Get(id);
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(News news)
        {
            if (ModelState.IsValid)
            {
                await _context.Delete(news);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}