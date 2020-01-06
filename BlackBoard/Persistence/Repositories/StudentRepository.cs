using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;

namespace BlackBoard.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.Include(c => c.Departments);
        }

        /// <summary>
        /// /Get single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            return _context.Students
                .Include(c => c.Departments)
                .SingleOrDefault(p => p.Id == id);
            //return _context.Students.Find(id);
        }
        /// <summary>
        /// Get newly added students
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetRecentStudents()
        {
            return _context.Students
                .Where(a => DbFunctions.DiffDays(a.DateTime, DateTime.Now) == 0)
                .Include(c => c.Departments);
        }



        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="student"></param>
        public void Add(Student student)
        {
            _context.Students.Add(student);
        }
        /// <summary>
        /// Delete existing student
        /// </summary>
        /// <param name="student"></param>
        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}