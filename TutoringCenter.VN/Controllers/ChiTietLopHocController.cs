using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Models.Session;

namespace TutoringCenter.VN.Controllers
{
    public class ChiTietLopHocController : BaseController
    {
        private readonly TutoringCenterDbContext _context;
        private readonly IDataRepository<Course> _course;
        public ChiTietLopHocController(TutoringCenterDbContext context, IDataRepository<Course> course)
        {
            _context = context;
            _course = course;
        }

        public async Task<IActionResult> Index(long id)
        {
            ViewBag.course = await _course.Get(id);

            Session sesion = GetSession();
            if (sesion != null && sesion.RoleHome.Equals("4"))
            {
                var dang_ky = _context.CourseStudents.Where(s => s.StudentId == Convert.ToInt32(sesion.idPerson) && s.CId == id).FirstOrDefault();
                if (dang_ky != null && dang_ky.CId > 0)
                {
                    ViewData["dang_ky"] = "1"; 
                    ViewData["thong_tin_dang_ky"] = dang_ky; 
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Course course, int? DanhGiaDiem)
        {
            ViewBag.course = await _course.Get(course.CId);

            Session sesion = GetSession();
            if (sesion == null || string.IsNullOrWhiteSpace(sesion.Id))
            {
                return RedirectToAction("Index", "Home");
            }

            var hsLop = _context.CourseStudents.Where(s => s.StudentId == Convert.ToInt32(sesion.idPerson) && s.CId == course.CId).FirstOrDefault();

            if (DanhGiaDiem == null || DanhGiaDiem == 0)
            {
                if (hsLop != null && hsLop.CId > 0)
                {
                    ViewData["da_dang_ky"] = "Học sinh đã đăng ký lớp học này!";
                    return View();
                }
                else
                {
                    CourseStudent courseStudent = new CourseStudent();
                    courseStudent.CId = course.CId;
                    courseStudent.StudentId = Convert.ToInt32(sesion.idPerson);
                    _context.CourseStudents.Add(courseStudent);
                    await _context.SaveChangesAsync();
                    ViewData["dang_ky_thanh_cong"] = "Học sinh đã đăng ký lớp học thành công!";
                }
            }
            else
            {
                hsLop.IsDanhGia = 1;
                hsLop.Diem = DanhGiaDiem;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
