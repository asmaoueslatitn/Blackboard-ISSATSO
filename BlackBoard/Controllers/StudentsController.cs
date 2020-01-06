using System;
using System.Linq;
using System.Web.Mvc;
using BlackBoard.Core;
using BlackBoard.Core.Models;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Controllers
{
    [Authorize(Roles = RoleName.TeacherRoleName + "," + RoleName.AdministratorRoleName)]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var viewModel = new StudentDetailViewModel()
            {
                Student = _unitOfWork.Students.GetStudent(id),
                Exams = _unitOfWork.Exams.GetExamWithStudent(id),
                Attendances = _unitOfWork.Attandences.GetAttendance(id),
                CountExams = _unitOfWork.Exams.CountExams(id),
                CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }




        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new StudentFormViewModel
            {
                Departments = _unitOfWork.Departments.GetDepartments(),
                Heading = "New Student"
            };
            return View("StudentForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _unitOfWork.Departments.GetDepartments();
                return View("StudentForm", viewModel);

            }

            var student = new Student
            {
                Name = viewModel.Name,
                LevelG = viewModel.LevelG,
                DateTime = DateTime.Now,
                SemesterDate = viewModel.GetBirthDate(),
              
                DepartmentId = viewModel.Department,
                DivisionD = viewModel.DivisionD,
                Token = (2018 + _unitOfWork.Students.GetStudents().Count()).ToString().PadLeft(7, '0')
            };

            _unitOfWork.Students.Add(student);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Students");

            // TODO: BUG redirect to detail 
            //return RedirectToAction("Details", new { id = viewModel.Id });
        }


        public ActionResult Edit(int id)
        {
            var student = _unitOfWork.Students.GetStudent(id);

            var viewModel = new StudentFormViewModel
            {
                Heading = "Edit Student",
                Id = student.Id,
                Name = student.Name,
              
                Date = student.DateTime,
                //Date = student.DateTime.ToString("d MMM yyyy"),
                SemesterDate = student.SemesterDate.ToString("dd/MM/yyyy"),
                 LevelG=student.LevelG,
                DivisionD = student.DivisionD,
                Department = student.DepartmentId,
                Departments = _unitOfWork.Departments.GetDepartments()
            };
            return View("StudentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StudentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _unitOfWork.Departments.GetDepartments();
                return View("StudentForm", viewModel);
            }


            var studentInDb = _unitOfWork.Students.GetStudent(viewModel.Id);
            studentInDb.Id = viewModel.Id;
            studentInDb.Name = viewModel.Name;
         

            studentInDb.SemesterDate = viewModel.GetBirthDate();
          
         
            studentInDb.DivisionD = viewModel.DivisionD;
            studentInDb.DepartmentId = viewModel.Department;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Students")
;
        }



    }
}