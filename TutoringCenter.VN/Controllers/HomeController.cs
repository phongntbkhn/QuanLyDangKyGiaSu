using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository<NewsCategory> _newCategories;
        private readonly IDataRepository<News> _news;
        private readonly IDataRepository<Teacher> _teacher;
        private readonly IDataRepository<Course> _course;
        private readonly IDataRepository<User> _user;
        private readonly IDataRepository<Feedback> _feedback;
        private readonly IDataRepository<AboutUs> _aboutUs;


        public HomeController(ILogger<HomeController> logger ,IDataRepository<AboutUs> aboutUs,IDataRepository<NewsCategory> newCategories, IDataRepository<News> news, IDataRepository<Teacher> teacher, IDataRepository<Course> course, IDataRepository<User> user, IDataRepository<Feedback> feedback)
        {
            _newCategories = newCategories;
            _news = news;
            _teacher = teacher;
            _course = course;
            _user = user;
            _feedback = feedback;
            _logger = logger;
            _aboutUs = aboutUs;
        }
        
        public IActionResult Index()
        {
            ViewBag.newsCategory = _newCategories.GetAll();
            ViewBag.news = _news.GetAll();
            ViewBag.teacher = _teacher.GetAll();
            ViewBag.course = _course.GetAll();
            ViewBag.feedbacks = _feedback.GetAll();
            ViewBag.aboutUs = _aboutUs.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
