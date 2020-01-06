using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
    }
}