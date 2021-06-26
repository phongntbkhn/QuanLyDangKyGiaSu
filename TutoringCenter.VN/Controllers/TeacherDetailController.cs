using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Controllers
{
    public class TeacherDetailController : Controller
    {
        private readonly IDataRepository<Teacher> _teacher;
        public TeacherDetailController(IDataRepository<Teacher> teacher) {
            _teacher = teacher;
        }
        public async Task<IActionResult> Index(long id)
        {
            ViewBag.teacher = await _teacher.Get(id);
            return View();
        }
    }
}