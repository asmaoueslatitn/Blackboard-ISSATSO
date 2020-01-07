using System.Web.Mvc;
using BlackBoard.Core;
using BlackBoard.Core.ViewModel;
using Microsoft.AspNet.Identity;

namespace BlackBoard.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var teachers = _unitOfWork.Teachers.GetTeachers();
            return View(teachers);
        }

        //Details for admin
        public ActionResult Details(int id)
        {
            var viewModel = new TeacherDetailViewModel
            {
                Teacher = _unitOfWork.Teachers.GetTeacher(id),
                UpcomingExams = _unitOfWork.Exams.GetTodaysExams(id),
                Exams = _unitOfWork.Exams.GetExamByTeacher(id),
            };
            return View(viewModel);
        }

        public ActionResult TeacherProfile()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new TeacherDetailViewModel
            {
                Teacher = _unitOfWork.Teachers.GetProfile(userId),
                Exams = _unitOfWork.Exams.GetUpcommingExams(userId),
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var teacher = _unitOfWork.Teachers.GetTeacher(id);
            if (teacher == null) return HttpNotFound();
            var viewModel = new TeacherFormViewModel()
            {

                Id = teacher.Id,
                Name = teacher.Name,
                Phone = teacher.Phone,
                Address = teacher.Address,
                IsAvailable = teacher.IsAvailable,
                Specialization = teacher.SpecializationId,
                Specializations = _unitOfWork.Specializations.GetSpecializations()

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TeacherFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();
                return View(viewModel);
            }

            var teacherInDb = _unitOfWork.Teachers.GetTeacher(viewModel.Id);
            teacherInDb.Id = viewModel.Id;
            teacherInDb.Name = viewModel.Name;
            teacherInDb.Phone = viewModel.Phone;
            teacherInDb.Address = viewModel.Address;
            teacherInDb.IsAvailable = viewModel.IsAvailable;
            teacherInDb.SpecializationId = viewModel.Specialization;

            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = viewModel.Id });
        }


    }

}

