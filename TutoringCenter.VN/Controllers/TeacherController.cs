using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Models.Session;

namespace TutoringCenter.VN.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly IDataRepository<Teacher> _teacher;
        public TeacherController(IDataRepository<Teacher> teacher)
        {
            _teacher = teacher;
        }

        public IActionResult Index(string tenGiangVien)
        {
            var tempTeacher = _teacher.GetAll();
            ViewBag.teacher = tempTeacher;
            if (tenGiangVien != null && !string.IsNullOrEmpty(tenGiangVien.Trim()))
            {
                ViewBag.teacher = tempTeacher.Where(s => s.DisplayName.Contains(tenGiangVien.Trim()));
            }
            return View();
        }

        public async Task<IActionResult> DangKyGiaSu(int id)
        {
            Session sesion = GetSession();
            if (sesion == null || string.IsNullOrWhiteSpace(sesion.Id))
            {
                return RedirectToAction("Index", "Home");
            }
            var teacher = await _teacher.Get(Convert.ToInt32(sesion.idPerson));
            if (teacher != null)
            {
                return View(teacher);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKyGiaSu(IFormFile avatar2, Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid && teacher != null && teacher.DisplayName != null && teacher.Description != null)
                {
                    if (avatar2 != null)
                    {
                        string newPath = "/Landing/assets/img/team/teacher_avatar_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await avatar2.CopyToAsync(fs);
                            teacher.Avatar = newPath;
                            if (teacher != null && teacher.TId > 0)
                            {
                                await _teacher.Update(await _teacher.Get(teacher.TId), teacher);
                            }
                            else
                            {
                                await _teacher.Add(teacher);
                            }
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(teacher.Avatar))
                        {
                            ViewData["ERROR_NOTIFY"] = "Chưa thêm ảnh đại diện";
                            return View();
                        }

                        if (teacher != null && teacher.TId > 0)
                        {
                            await _teacher.Update(await _teacher.Get(teacher.TId), teacher);
                        }
                        else
                        {
                            await _teacher.Add(teacher);
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho gia sư này";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewData["ERROR_NOTIFY"] = "Đã xảy ra lỗi khi đăng ký mới gia sư";
                return View();
            }
        }
    }
}