using System.Linq;
using System.Web.Mvc;
using BlackBoard.Core;
using BlackBoard.Core.Models;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var exams = _unitOfWork.Exams.GetExams();
            return View(exams);
        }

        public ActionResult Details(int id)
        {
            var exam = _unitOfWork.Exams.GetExamWithStudent(id);
            return View("_ExamPartial", exam);
        }

        public ActionResult Create(int id)
        {
            var viewModel = new ExamFormViewModel
            {
                Student = id,
                Teachers = _unitOfWork.Teachers.GetAvailableTeachers(),

                Heading = "New Exam"
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Teachers = _unitOfWork.Teachers.GetAvailableTeachers();
                return View(viewModel);

            }
            var exam = new Exam()
            {
                StartDateTime = viewModel.GetStartDateTime(),
                Detail = viewModel.Detail,
                Status = false,
                StudentId = viewModel.Student,
                Teacher = _unitOfWork.Teachers.GetTeacher(viewModel.Teacher)

            };
            //Check if the slot is available
            if (_unitOfWork.Exams.ValidateExam(exam.StartDateTime, viewModel.Teacher))
                return View("InvalidExam");

            _unitOfWork.Exams.Add(exam);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Exams");
        }

        public ActionResult Edit(int id)
        {
            var exam = _unitOfWork.Exams.GetExam(id);
            var viewModel = new ExamFormViewModel()
            {
                Heading = "New Exam",
                Id = exam.Id,
                Date = exam.StartDateTime.ToString("dd/MM/yyyy"),
                Time = exam.StartDateTime.ToString("HH:mm"),
                Detail = exam.Detail,
                Status = exam.Status,
                Student = exam.StudentId,
                Teacher = exam.TeacherId,
                Teachers = _unitOfWork.Teachers.GetTeachers()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Teachers = _unitOfWork.Teachers.GetTeachers();
                viewModel.Students = _unitOfWork.Students.GetStudents();
                return View(viewModel);
            }

            var examInDb = _unitOfWork.Exams.GetExam(viewModel.Id);
            examInDb.Id = viewModel.Id;
            examInDb.StartDateTime = viewModel.GetStartDateTime();
            examInDb.Detail = viewModel.Detail;
            examInDb.Status = viewModel.Status;
            examInDb.StudentId = viewModel.Student;
            examInDb.TeacherId = viewModel.Teacher;

            _unitOfWork.Complete();
            return RedirectToAction("Index");

        }

        public ActionResult TeachersList()
        {
            var teachers = _unitOfWork.Teachers.GetAvailableTeachers();
            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(teachers.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Create");
        }

        public PartialViewResult GetUpcommingExams(int id)
        {
            var exams = _unitOfWork.Exams.GetTodaysExams(id);
            return PartialView(exams);
        }

    }
}