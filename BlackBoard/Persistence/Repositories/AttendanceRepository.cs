using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;

namespace BlackBoard.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetAttandences()
        {
            return _context.Attendances.ToList();
        }
        /// <summary>
        /// Get attandences for single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetAttendance(int id)
        {
            return _context.Attendances.Where(p => p.StudentId == id).ToList();
        }
        /// <summary>
        /// search  attandences for student by token 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<Attendance> GetStudentAttandences(string searchTerm = null)
        {
            var attandences = _context.Attendances.Include(p => p.Student);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                attandences = attandences.Where(p => p.Student.Token.Contains(searchTerm));
            }
            return attandences.ToList();
        }
        /// <summary>
        /// Get number of attendances for defined student 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAttendances(int id)
        {
            return _context.Attendances.Count(a => a.StudentId == id);
        }
        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }
    }
}