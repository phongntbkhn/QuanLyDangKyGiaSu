using Microsoft.AspNetCore.Authorization;
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

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "0")]
    public class UserController : Controller
    {
        private readonly IDataRepository<User> _context;
        public UserController(IDataRepository<User> context)
        {
            _context = context;
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
            return View(new User());
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
        public async Task<IActionResult> Upload(IFormFile avatar, User user)
        {
            try
            {
                if (ModelState.IsValid && user != null)
                {
                   if (avatar != null)
                    {
                        string newPath = "/Admin/assets/images/users/user_avatar_" + Stopwatch.GetTimestamp() + ".png";
                        using (var fs = new FileStream("./wwwroot/" + newPath, FileMode.Create))
                        {
                            await avatar.CopyToAsync(fs);
                            user.Avatar = newPath;
                            if (user != null && user.UId > 0)
                            {
                                if (user.EncryptPassword.Length < 8)
                                    throw new Exception("Mật khẩu tối thiểu là 8 ký tự");
                               await _context.Update(await _context.Get(user.UId), user);
                            }
                            else
                            {
                               await _context.Add(user);
                            }
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ERROR_NOTIFY"] = "Có thể bạn chưa nhập tên cho giảng viên này";
                }
            }
            catch (Exception e)
            {
                TempData["ERROR_NOTIFY"] = "Chưa chọn ảnh cho giảng viên này";
                System.Console.WriteLine(e.Message);
                if (user != null && user.UId > 0)
                {
                    if (user.EncryptPassword.Length < 8)
                    {
                        TempData["ERROR_NOTIFY"] = "Mật khẩu tối thiểu phải đạt 8 ký tự";
                    }
                    else
                    {
                        TempData["ERROR_NOTIFY"] = "";
                       await _context.Update(await _context.Get(user.UId), user);
                        return RedirectToAction("Index");
                    }
                }
            }
            if (user != null && user.UId >= 0)
            {
                return RedirectToAction("Update", new { id = user.UId });
            }
            else
            {
                return RedirectToAction("Create");
            }
        }




        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var user = await _context.Get(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(User user)
        {
            if (ModelState.IsValid)
            {
               await _context.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}