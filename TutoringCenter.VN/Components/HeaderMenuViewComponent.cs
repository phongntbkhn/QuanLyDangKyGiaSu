using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private readonly IDataRepository<NewsCategory> _context;
        private readonly IDataRepository<CommonQuestion> _commonQuestion;

        public HeaderMenuViewComponent(IDataRepository<NewsCategory> context, IDataRepository<CommonQuestion> commonQuestion)
        {
            _context = context;
            _commonQuestion = commonQuestion;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.GetAll();
            ViewBag.commonQuestions = _commonQuestion.GetAll();
            return View(categories);
        }
    }
}
