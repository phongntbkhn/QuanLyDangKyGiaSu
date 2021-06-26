using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager _context;
        public LoginController(IDataRepository<User> context)
        {
            _context = (UserManager)context;
        }
        public IActionResult Index()
        {
            ViewBag.notification = TempData["ERROR"];
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var foundUser = await _context.Find(user.Username.ToLower(), user.EncryptPassword);
            if (foundUser == null)
            {
                TempData["ERROR"] = "Sai tài khoản hoặc mật khẩu!";
                return RedirectToAction("Index");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim("ID", foundUser.UId.ToString()),
                    new Claim(ClaimTypes.Name, foundUser.DisplayName),
                    new Claim(ClaimTypes.Role, foundUser.Role.ToString()),
                    new Claim("AVATAR", foundUser.Avatar == null?"":foundUser.Avatar)
                };
                var identify = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme
                );
                var principal = new ClaimsPrincipal(identify);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}