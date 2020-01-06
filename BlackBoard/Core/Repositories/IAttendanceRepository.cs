using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAttandences();
        IEnumerable<Attendance> GetAttendance(int id);
        IEnumerable<Attendance> GetStudentAttandences(string searchTerm = null);
        int CountAttendances(int id);
        void Add(Attendance attendance);
    }
}
