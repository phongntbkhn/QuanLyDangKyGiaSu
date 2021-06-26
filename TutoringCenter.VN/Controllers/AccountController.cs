using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;
using TutoringCenter.VN.Models.Session;
using TutoringCenter.VN.Utils;

namespace TutoringCenter.VN.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager _user;
        private readonly IDataRepository<Teacher> _teacher;
        private readonly IDataRepository<Student> _student;

        public AccountController(IDataRepository<User> user
            , IDataRepository<Teacher> teacher
            , IDataRepository<Student> student
            )
        {
            _user = (UserManager)user;
            _teacher = teacher;
            _student = student;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var foundUser = await _user.Find(user.Username.ToLower(), user.EncryptPassword);
            if (foundUser == null)
            {
                ViewData["error_msg"] = "Sai tài khoản hoặc mật khẩu!";
                return View();
            }
            else
            {
                Session session = new Session();
                session.Id = foundUser.UId.ToString();
                session.UserName = foundUser.Username;
                session.RoleHome = foundUser.RoleHome.ToString();
                if (foundUser.RoleHome == 2)
                {
                    var person = _teacher.GetAlbyUId(foundUser.UId).FirstOrDefault();
                    session.idPerson = person.TId.ToString();
                }
                else if (foundUser.RoleHome == 4)
                {
                    var person = _student.GetAlbyUId(foundUser.UId).FirstOrDefault();
                    session.idPerson = person.SId.ToString();
                }

                SetSession(session);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            string password = user.EncryptPassword;
            int resultRegister = await _user.Add(user);
            if (resultRegister != 1)
            {
                ViewData["error_msg"] = "Đăng ký tài khoản thất bại!";
                return View();
            }
            else
            {
                var registerUser = await _user.Find(user.Username.ToLower(), password);
                if (user.RoleHome == 2 && registerUser != null)
                {
                    Teacher teacher = new Teacher();
                    teacher.DisplayName = user.DisplayName;
                    teacher.Status = Consstant.STATUS_DANG_KY;
                    teacher.UId = registerUser.UId;

                    int resultAddTeacher = await _teacher.Add(teacher);
                    if (resultAddTeacher != 1)
                    {
                        ViewData["error_msg"] = "Đăng ký tài khoản gia sư thất bại!";
                        return View();
                    }
                }
                else if (user.RoleHome == 4 && registerUser != null)
                {
                    Student student = new Student();
                    student.TenHocSinh = user.DisplayName;
                    student.Status = Consstant.STATUS_DANG_KY;
                    student.UId = registerUser.UId;
                    int resultAddStudent = await _student.Add(student);
                    if (resultAddStudent != 1)
                    {
                        ViewData["error_msg"] = "Đăng ký tài khoản gia sư thất bại!";
                        return View();
                    }
                }
                else
                {
                    ViewData["error_msg"] = "Bạn chưa chọn chức vụ! ";
                    return View();
                }
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Logout()
        {
            RemoveSession();
            return RedirectToAction("Login", "Account");
        }
    }
}
