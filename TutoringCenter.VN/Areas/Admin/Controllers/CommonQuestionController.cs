using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "0,1")]
    public class CommonQuestionController : Controller
    {
        private readonly IDataRepository<CommonQuestion> _context;
        public CommonQuestionController(IDataRepository<CommonQuestion> context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var commonQuestionList = _context.GetAll();
            return View(commonQuestionList);
        }
        public IActionResult Create()
        {
            ViewBag.notification = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommonQuestion commonQuestion)
        {
            if (ModelState.IsValid)
            {
                commonQuestion.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                await _context.Add(commonQuestion);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(long id)
        {
            ViewBag.notification = "";
            var commonQuestion = await _context.Get(id);
            return View(commonQuestion);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CommonQuestion commonQuestion)
        {
            if (ModelState.IsValid)
            {
                commonQuestion.UId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                commonQuestion.UpdateAt = DateTime.Now;
                var commonQuestionDb = await _context.Get(commonQuestion.CQId);
                await _context.Update(commonQuestionDb, commonQuestion);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.notification = "";
            var commonQuestion = await _context.Get(id);
            return View(commonQuestion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(CommonQuestion commonQuestion)
        {
            if (ModelState.IsValid)
            {
                await _context.Delete(commonQuestion);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.notification = "Dữ liệu nhập vào không hợp lệ";
            return View();
        }
    }
}