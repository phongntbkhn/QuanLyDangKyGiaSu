using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Models.Session;

namespace TutoringCenter.VN.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IDataRepository<Student> _student;
        public StudentController(IDataRepository<Student> student)
        {
            _student = student;
        }


        public async Task<IActionResult> DangKyHocSinh(int id)
        {
            Session sesion = GetSession();
            if (sesion == null || string.IsNullOrWhiteSpace(sesion.Id))
            {
                return RedirectToAction("Index", "Home");
            }

            var student = await _student.Get(Convert.ToInt32(sesion.idPerson));
            if (student != null)
            {
                return View(student);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKyHocSinh(Student student)
        {
            try
            {
                if (ModelState.IsValid && student != null && student.TenHocSinh != null)
                {
                    if (student != null && student.SId > 0)
                    {
                        await _student.Update(await _student.Get(student.SId), student);
                    }
                    else
                    {
                        await _student.Add(student);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ERROR_NOTIFY"] = "Bạn chưa nhập tên học sinh";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewData["ERROR_NOTIFY"] = "Đã xảy ra lỗi khi cập nhật học sinh";
                return View();
            }
        }
    }
}
