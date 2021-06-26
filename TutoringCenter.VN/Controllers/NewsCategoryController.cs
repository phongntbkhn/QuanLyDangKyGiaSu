using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Controllers
{
    [Route("[controller]")]
    public class NewsCategoryController : Controller
    {
        private readonly IDataRepository<News> _news;
        private readonly IDataRepository<NewsCategory> _newsCategory;
        public NewsCategoryController(IDataRepository<News> news, IDataRepository<NewsCategory> newsCategory)
        {
            _news = news;
            _newsCategory = newsCategory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                var arrs = id.Split("-");
                try
                {
                    var categoryId = Int64.Parse(arrs[^1]);
                    var newsCategory = await _newsCategory.Get(categoryId);
                    var newCategories = _newsCategory.GetAll();
                    ViewBag.news = ((NewsManager)_news).GetAll(categoryId);
                    ViewBag.newCategories = newCategories;
                    return View(newsCategory);
                }
                catch (Exception)
                {
                    // Không chuyển sang số được
                }
            }
            return NotFound();
        }
    }
}