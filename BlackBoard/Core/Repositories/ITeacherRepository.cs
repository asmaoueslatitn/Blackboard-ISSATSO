using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetDectors();
        IEnumerable<Teacher> GetAvailableTeachers();
        Teacher GetTeacher(int id);
        Teacher GetProfile(string userId);
        void Add(Teacher teacher);
    }
}