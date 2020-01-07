using System.Collections.Generic;
using System.Linq;
using BlackBoard.Core.Dto;
using BlackBoard.Core.Models;
using BlackBoard.Core.Repositories;

namespace BlackBoard.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}