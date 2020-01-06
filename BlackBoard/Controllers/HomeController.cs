using System;
using BlackBoard.Persistence;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BlackBoard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Dashboard Statistics
        public ActionResult TotalStudents()
        {
            var students = _context.Students.ToList();
            return Json(students.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalExams()
        {
            var exams =_context.Exams.ToList();
            return Json(exams.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalTeachers()
        {
            var teachers = _context.Teachers.ToList();
            return Json(teachers.Count(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalUsers()
        {
            var users=_context.Users.ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
        }

        //Today's students
        public ActionResult TodaysStudents()
        {
            DateTime today = DateTime.Now.Date;
            var students = _context.Students.Where(p => p.DateTime >= today).ToList();
            return Json(students.Count(), JsonRequestBehavior.AllowGet);
        }
        //Todays exams
        public ActionResult TodaysExams()
        {
            DateTime today = DateTime.Now.Date;
            var exams =_context.Exams
                .Where(a => a.StartDateTime >= today)
                .ToList();
            return Json(exams.Count(), JsonRequestBehavior.AllowGet);
        }
        //Available teachers
        public ActionResult AvailableTeachers()
        {
            var teachers=_context.Teachers
                .Where(d => d.IsAvailable)
                .ToList();
            return Json(teachers.Count(), JsonRequestBehavior.AllowGet);
        }
        //Active Accounts
        public ActionResult ActiveAccounts()
        {
            var users =_context.Users
                .Where(u => u.IsActive == true)
                .ToList();
            return Json(users.Count(), JsonRequestBehavior.AllowGet);
        }
        
        #endregion



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}