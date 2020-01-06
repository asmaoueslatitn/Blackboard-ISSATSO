using System;
using System.Web.Mvc;
using BlackBoard.Core;
using BlackBoard.Core.Models;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Details(int id)
        {
            var attendance = _unitOfWork.Attandences.GetAttendance(id);
            return View("_attendancePartial", attendance);
        }

        public ActionResult Create(int id)
        {
            var viewModel = new AttendanceFormViewModel
            {
                Student = id,
                Heading = "Add Attendance"
            };
            return View("AttendanceForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(AttendanceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("AttendanceForm", viewModel);

            var attendance = new Attendance
            {
                Id = viewModel.Id,
                ExamRemarks = viewModel.ExamRemarks,
                Interpretation = viewModel.Interpretation,
                SecondInterpretation = viewModel.SecondInterpretation,
                ThirdInterpretation = viewModel.ThirdInterpretation,
                RecoverCandidate = viewModel.RecoverCandidate,
                Date = DateTime.Now,
                Student = _unitOfWork.Students.GetStudent(viewModel.Student)
            };
            _unitOfWork.Attandences.Add(attendance);
            _unitOfWork.Complete();
            //ViewBag.Confirm = "Successfully Saved";
            //return PartialView("_Confirmation");
            return RedirectToAction("Details", "Students", new { id = viewModel.Student });
        }



    }
}