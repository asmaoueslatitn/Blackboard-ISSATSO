using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;

namespace BlackBoard.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teachers
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }

        /// <summary>
        /// Get the available teachers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Teacher> GetAvailableTeachers()
        {
            return _context.Teachers
                .Where(a => a.IsAvailable == true)
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }
        /// <summary>
        /// Get single Teacher - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher GetTeacher(int id)
        {
            return _context.Teachers
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.Id == id);
        }

        public Teacher GetProfile(string userId)
        {
            return _context.Teachers
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.PhysicianId == userId);
        }
        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }
    }
}