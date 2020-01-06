using System;
using System.Web.Mvc;
using BlackBoard.Core;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //======================Attandance ========================//
        public ActionResult Attandences()
        {
            var attandences = _unitOfWork.Attandences.GetAttandences();
            return View(attandences);
        }
        public ActionResult StudentAttandence(string token = null)
        {
            var studentAttandences = _unitOfWork.Attandences.GetStudentAttandences(token);
            return View("_AttandencePartial", studentAttandences);
        }

        // ===============Exam ========================//
        public ActionResult Exams()
        {
            var exams = _unitOfWork.Exams.GetExams();
            return View(exams);
        }

        [HttpPost]
        public ActionResult Exams(ExamSearchVM viewModel)
        {
            var filter = _unitOfWork.Exams.FilterExams(viewModel);
            return View(filter);
        }
        public ActionResult TestExam(ExamSearchVM viewModel)
        {
            var filter = _unitOfWork.Exams.FilterExams(viewModel);
            return PartialView("_Exams", filter);
        }
        //===============End Exam===================//

        //====================Daily exam==============//

        public ActionResult DaillyExams()
        {
            var daily = _unitOfWork.Exams.GetExams();
            return View(daily);
        }

        public ActionResult Dailly(DateTime getDate)
        {
            var dailyExams = _unitOfWork.Exams.GetDaillyExams(getDate);
            return View("_DailyExams", dailyExams);
        }
    }
}