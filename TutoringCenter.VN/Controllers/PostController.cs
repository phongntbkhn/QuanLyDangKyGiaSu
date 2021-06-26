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
    public class PostController : Controller
    {
        private readonly IDataRepository<News> _news;
        private readonly IDataRepository<NewsCategory> _newsCategory;
        private readonly IDataRepository<Feedback> _feedback;
        public PostController(IDataRepository<News> news, IDataRepository<NewsCategory> newsCategory, IDataRepository<Feedback> feedback)
        {
            _news = news;
            _newsCategory = newsCategory;
            _feedback = feedback;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                var arrs = id.Split("-");
                try
                {
                    var newsId = Int64.Parse(arrs[arrs.Length - 1]);
                    var newss = await _news.Get(newsId);
                    var newCategories = _newsCategory.GetAll();
                    ViewBag.news = ((NewsManager)_news).GetSize(5);
                    ViewBag.newCategories = newCategories;
                    ViewBag.nextNews = ((NewsManager)_news).GetNextPost(newsId, newss.NCId);
                    ViewBag.previousNews = ((NewsManager)_news).GetPreviousPost(newsId, newss.NCId);
                    ViewBag.currentPost = newss;
                    Feedback f = new Feedback();
                    f.Address = "Feedback từ [" + newss.GetPath() + "]";
                    return View(f);
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