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
    public class TeacherController : Controller
    {
        private readonly IDataRepository<Teacher> _context;
        public TeacherController(IDataRepository<Teacher> context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(_context.GetAll());
        }
        public IActionResult Create()
        {
            if (TempData["ERROR_NOTIFY"] != null)
            {
                ViewBag.notification = TempData["ERROR_NOTIFY"];
            }
            return View();
        }
        public async Task<IActionResult> Update(long id)
        {
            if (TempData["ERROR_NOTIFY"] != null)
            {
                ViewBag.notification = TempData["ERROR_NOTIFY"];
            }
            return View(await _context.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile avatar, Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid && teacher != null && teacher.DisplayName != null && teacher.Description != null)
                {
                    if (avatar != null)
                    {
                        string newPath = "/landing/assets/img/team/teacher_avatar_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await avatar.CopyToAsync(fs);
                            teacher.Avatar = newPath;
                            if (teacher != null && teacher.TId > 0)
                            {
                              await  _context.Update(await _context.Get(teacher.TId), teacher);
                            }
                            else
                            {
                               await _context.Add(teacher);
                            }
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho gia sư này";
                }
            }
            catch (Exception)
            {
                if (teacher != null && teacher.TId > 0)
                {
                  await  _context.Update(await _context.Get(teacher.TId), teacher);
                    return RedirectToAction("Index");
                }
                TempData["ERROR_NOTIFY"] = "Chưa chọn ảnh cho giảng viên này";
            }
            if (teacher != null && teacher.TId > 0)
            {
                return RedirectToAction("Update", new { id = teacher.TId });
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var teacher = await _context.Get(id);
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _context.Delete(teacher);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}