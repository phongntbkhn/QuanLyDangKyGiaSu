using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Models.Session;

namespace TutoringCenter.VN.Controllers
{
    public class LopHocController : BaseController
    {
        private readonly IDataRepository<Course> _course;
        private readonly IDataRepository<Teacher> _teacher;

        public LopHocController(IDataRepository<Course> course, IDataRepository<Teacher> teacher)
        {
            _course = course;
            _teacher = teacher;
        }

        public IActionResult Index(int? idKhoi, string tenLopHoc)
        {
            var lopHoc = _course.GetAll();
            var resultLopHoc = lopHoc;

            ViewBag.course = lopHoc;
            if (tenLopHoc != null && !string.IsNullOrEmpty(tenLopHoc.Trim()))
            {
                resultLopHoc = resultLopHoc.Where(s => s.Name.Contains(tenLopHoc.Trim()));
            }

            if (idKhoi != null && idKhoi > 0)
            {
                resultLopHoc = resultLopHoc.Where(s => s.IdKhoi == idKhoi);
            }

            ViewBag.course = resultLopHoc;
            return View();
        }

        public IActionResult DanhSachLop(int? idGiaSu)
        {
            var lopHoc = _course.GetAll();
            var resultLopHoc = lopHoc;

            ViewBag.course = lopHoc;
            if (idGiaSu != null && idGiaSu > 0)
            {
                resultLopHoc = resultLopHoc.Where(s => s.TId == idGiaSu);
            }

            ViewBag.course = resultLopHoc;
            return View();
        }

        public async Task<IActionResult> Create(long id, Course course = null)
        {
            Session sesion = GetSession();
            if (sesion == null || string.IsNullOrWhiteSpace(sesion.Id))
            {
                return RedirectToAction("Index", "Home");
            }

            var t = await _teacher.Get(Convert.ToInt32(sesion.idPerson));
            if (t == null)
            {
                throw new Exception("Không có giáo viên này");
            }
            else
            {
                ViewBag.teacher = t;
                if (course == null)
                    course = new Course();
                course.TId = (int)id;
                return View(course);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile FileImage, Course course)
        {
            try
            {
                if (ModelState.IsValid && course != null && course.Name != null)
                {
                    if (FileImage != null)
                    {
                        string newPath = "/landing/assets/img/course/corse_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await FileImage.CopyToAsync(fs);
                            course.Image = newPath;
                            if (course != null && course.CId > 0)
                            {
                                await _course.Update(await _course.Get(course.CId), course);
                            }
                            else
                            {
                                await _course.Add(course);
                            }
                        }
                    }
                    else
                    {
                        if (course != null && course.CId > 0)
                        {
                            await _course.Update(await _course.Get(course.CId), course);
                        }
                        else
                        {
                            await _course.Add(course);
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho khóa học này";
                }
            }
            catch (Exception ex)
            {
                if (course != null && course.CId > 0)
                {
                    await _course.Update(await _course.Get(course.CId), course);
                    return RedirectToAction("Index");
                }
                TempData["ERROR_NOTIFY"] = "Chưa chọn ảnh cho khóa học này";
            }
            if (course != null && course.CId > 0)
            {
                return RedirectToAction("Update", new { id = course.CId });
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public async Task<IActionResult> Update(long? id, Course course = null)
        {
            Session sesion = GetSession();
            if (sesion == null || string.IsNullOrWhiteSpace(sesion.Id))
            {
                return RedirectToAction("Index", "Home");
            }

            var t = await _teacher.Get(Convert.ToInt32(sesion.idPerson));
            if (t == null)
            {
                throw new Exception("Không có giáo viên này");
            }
            else
            {
                if (id != null && id>0)
                {
                    course = await _course.Get((int)id);
                }

                ViewBag.teacher = t;
                if (course == null)
                    course = new Course();
                course.TId = (int)id;
                return View(course);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(IFormFile FileImage, Course course)
        {
            try
            {
                if (ModelState.IsValid && course != null && course.Name != null)
                {
                    if (FileImage != null)
                    {
                        string newPath = "/landing/assets/img/course/corse_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await FileImage.CopyToAsync(fs);
                            course.Image = newPath;
                            if (course != null && course.CId > 0)
                            {
                                await _course.Update(await _course.Get(course.CId), course);
                            }
                            else
                            {
                                await _course.Add(course);
                            }
                        }
                    }
                    else
                    {
                        if (course != null && course.CId > 0)
                        {
                            await _course.Update(await _course.Get(course.CId), course);
                        }
                        else
                        {
                            await _course.Add(course);
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho khóa học này";
                }
            }
            catch (Exception ex)
            {
                if (course != null && course.CId > 0)
                {
                    await _course.Update(await _course.Get(course.CId), course);
                    return RedirectToAction("Index");
                }
                TempData["ERROR_NOTIFY"] = "Chưa chọn ảnh cho khóa học này";
            }
            if (course != null && course.CId > 0)
            {
                return RedirectToAction("Update", new { id = course.CId });
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
    }
}
