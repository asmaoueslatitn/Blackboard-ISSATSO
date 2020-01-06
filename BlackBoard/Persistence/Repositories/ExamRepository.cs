using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Persistence.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all exams
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Exam> GetExams()
        {
            return _context.Exams
                .Include(p => p.Student)
                .Include(d => d.Teacher)
                .ToList();
        }
        /// <summary>
        /// Get exams for single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Exam> GetExamWithStudent(int id)
        {
            return _context.Exams
                .Where(p => p.StudentId == id)
                .Include(p => p.Student)
                .Include(d => d.Teacher)
                .ToList();
        }
        /// <summary>
        /// Get exams for single teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Exam> GetExamByTeacher(int id)
        {
            //return (from a in _context.Exams where a.TeacherId == id select a).AsEnumerable();

            return _context.Exams
                .Where(d => d.TeacherId == id)
                .Include(p => p.Student)
                .ToList();
        }

        /// <summary>
        /// Get upcomming exams for teacher - Admin section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Exam> GetTodaysExams(int id)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Exams
                .Where(d => d.TeacherId == id && d.StartDateTime >= today)
                .Include(p => p.Student)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }
        /// <summary>
        /// Get upcomming exams for specific teacher
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Exam> GetUpcommingExams(string userId)
        {
            DateTime today = DateTime.Now.Date;
            return _context.Exams
                .Where(d => d.Teacher.PhysicianId == userId && d.StartDateTime >= today && d.Status==true)
                .Include(p => p.Student)
                .OrderBy(d => d.StartDateTime)
                .ToList();
        }

        public IQueryable<Exam> FilterExams(ExamSearchVM searchModel)
        {
            var result = _context.Exams.Include(p => p.Student).Include(d => d.Teacher).AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(searchModel.Name))
                    result = result.Where(a => a.Teacher.Name == searchModel.Name);
                if (!string.IsNullOrWhiteSpace(searchModel.Option))
                {
                    if (searchModel.Option == "ThisMonth")
                    {
                        result = result.Where(x => x.StartDateTime.Year == DateTime.Now.Year && x.StartDateTime.Month == DateTime.Now.Month);
                    }
                    else if (searchModel.Option == "Pending")
                    {
                        result = result.Where(x => x.Status == false);
                    }
                    else if (searchModel.Option == "Approved")
                    {
                        result = result.Where(x => x.Status);
                    }
                }
            }

            return result;

        }
        /// <summary>
        /// Get Daily exams
        /// </summary>
        /// <param name="getDate"></param>
        /// <returns></returns>
        public IEnumerable<Exam> GetDaillyExams(DateTime getDate)
        {
            return _context.Exams.Where(a => DbFunctions.DiffDays(a.StartDateTime, getDate) == 0)
                .Include(p => p.Student)
                .Include(d => d.Teacher)
                .ToList();
        }

        /// <summary>
        /// Validate exam date and time
        /// </summary>
        /// <param name="appntDate"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ValidateExam(DateTime appntDate, int id)
        {
            return _context.Exams.Any(a => a.StartDateTime == appntDate && a.TeacherId == id);
        }
        /// <summary>
        /// Get number of exams for defined student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountExams(int id)
        {
            return _context.Exams.Count(a => a.StudentId == id);
        }


        /// <summary>
        /// Get single exam
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Exam GetExam(int id)
        {
            return _context.Exams.Find(id);
        }

        public void Add(Exam exam)
        {
            _context.Exams.Add(exam);
        }

    }
}