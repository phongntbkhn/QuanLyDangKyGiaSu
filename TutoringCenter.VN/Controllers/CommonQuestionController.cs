using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN.Controllers
{
    [Route("[controller]")]
    public class CommonQuestionController : Controller
    {
        IDataRepository<CommonQuestion> _commonQuestion;
        public CommonQuestionController(IDataRepository<CommonQuestion> commonQuestion) {
            _commonQuestion = commonQuestion;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if(id != null){
                var arrs = id.Split("-");
                try
                {
                    var commonQuestionId = Int64.Parse(arrs[^1]);
                    var commonQuestion = await _commonQuestion.Get(commonQuestionId);
                    ViewBag.commonQuestion = commonQuestion;
                    return View(commonQuestion);
                }
                catch (Exception)
                {
                    // Không chuyển sang số được
                }
            }
            return NotFound();
        }
    }
}