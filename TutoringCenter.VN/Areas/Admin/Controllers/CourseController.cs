using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "0,2")]
    public class CourseController : Controller
    {
        private readonly IDataRepository<Course> _context;
        private readonly IDataRepository<Teacher> _teacher;
        public CourseController(IDataRepository<Course> context, IDataRepository<Teacher> teacher)
        {
            _context = context;
            _teacher = teacher;
        }
        public IActionResult Index()
        {
            ViewBag.teachers = _teacher.GetAll();
            return View(_context.GetAll());
        }
        public async Task<IActionResult> Create(long id, Course course = null)
        {
            var t = await _teacher.Get(id);
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
        public async Task<IActionResult> Create(IFormFile Image, Course course)
        {
            try
            {
                if (ModelState.IsValid && course != null && course.Name != null)
                {
                    if (Image != null)
                    {
                        string newPath = "/landing/assets/img/course/corse_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await Image.CopyToAsync(fs);
                            course.Image = newPath;
                            if (course != null && course.CId > 0)
                            {
                                await _context.Update(await _context.Get(course.CId), course);
                            }
                            else
                            {
                                await _context.Add(course);
                            }
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho khóa học này";
                }
            }
            catch (Exception)
            {
                if (course != null && course.CId > 0)
                {
                    await _context.Update(await _context.Get(course.CId), course);
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

        [HttpPost]
        public async Task<IActionResult> Update(IFormFile Image, Course course)
        {
            try
            {
                if (ModelState.IsValid && course != null && course.Name != null)
                {
                    if (Image != null)
                    {
                        string newPath = "/landing/assets/img/course/corse_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await Image.CopyToAsync(fs);
                            course.Image = newPath;
                            if (course != null && course.CId > 0)
                            {
                                await _context.Update(await _context.Get(course.CId), course);
                            }
                            else
                            {
                                await _context.Add(course);
                            }
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho khóa học này";
                }
            }
            catch (Exception)
            {
                if (course != null && course.CId > 0)
                {
                    await _context.Update(await _context.Get(course.CId), course);
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

        //[HttpPost]
        //public IActionResult ImageUpload(IFormFile upload)
        //{
        //    var filename = DateTime.Now.ToString("yyyyMMddHHmmss_") + upload.FileName;
        //    var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
        //    if (!Directory.Exists(pathFile))
        //    {
        //        Directory.CreateDirectory(pathFile);
        //    }
        //    pathFile = Path.Combine(pathFile, filename);
        //    Console.WriteLine(pathFile);
        //    var stream = new FileStream(pathFile, FileMode.CreateNew);
        //    upload.CopyToAsync(stream);
        //    return new JsonResult(new { path = "/Uploads/" + filename });
        //}

        public async Task<IActionResult> Update(long? id, Course course = null)
        {
            if (id != null)
            {
                course = await _context.Get((int)id);
            }
            var t = await _teacher.Get(course.TId);
            if (t == null)
            {
                throw new Exception("Không có giáo viên này");
            }
            else
            {
                ViewBag.teacher = t;
                return View(course);
            }
        }

        //[HttpPost, ActionName("Update")]
        //public async Task<IActionResult> UpdateNow(Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (course.Name == null || course.Description == null || course.Detail == null
        //            || course.Image == null || course.LearningTime == null || course.Schedule == null)
        //        {
        //            ViewBag.notification = "Vui lòng nhập đầy đủ dữ liệu";
        //            return RedirectToAction("Create", new { id = course.TId });
        //        }
        //        else
        //        {
        //            await _context.Update(await _context.Get(course.CId), course);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
        //        return RedirectToAction("Update", new { id = course.CId });
        //    }
        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> Delete(long id)
        {
            return View(await _context.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNow(long id)
        {
            await _context.Delete(await _context.Get(id));
            return RedirectToAction("Index");
        }
    }
}