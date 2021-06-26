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
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDataRepository<NewsCategory> _newCategories;
        private readonly IDataRepository<News> _news;
        private readonly IDataRepository<Teacher> _teacher;
        private readonly IDataRepository<Course> _course;
        private readonly IDataRepository<User> _user;
        private readonly IDataRepository<Feedback> _feedback;
        public HomeController(IDataRepository<NewsCategory> newCategories, IDataRepository<News> news, IDataRepository<Teacher> teacher, IDataRepository<Course> course, IDataRepository<User> user, IDataRepository<Feedback> feedback)
        {
            _newCategories = newCategories;
            _news = news;
            _teacher = teacher;
            _course = course;
            _user = user;
            _feedback = feedback;
        }
        public IActionResult Index()
        {
            ViewBag.newsCategoryCount = _newCategories.GetAll().Count();
            ViewBag.newsCount = _news.GetAll().Count();
            ViewBag.teacherCount = _teacher.GetAll().Count();
            ViewBag.newTeacherCount = _teacher.GetAlbyIntPara(0).Count();
            ViewBag.courseCount = _course.GetAll().Count();
            ViewBag.feedbacks = _feedback.GetAll();
            return View(_user.GetAll());
        }
        public async Task<IActionResult> DeleteFeedback(long id)
        {
            if (ModelState.IsValid)
            {
                var feedback = await _feedback.Get(id);
                await _feedback.Delete(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
    }
}