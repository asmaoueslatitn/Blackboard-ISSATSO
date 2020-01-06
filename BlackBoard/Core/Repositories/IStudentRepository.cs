using System.Collections.Generic;
using System.Linq;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Student> GetRecentStudents();
        //IEnumerable<Student> GetStudentByToken(string searchTerm = null);
        Student GetStudent(int id);
        //IQueryable<Student> GetStudentQuery(string query);
        void Add(Student student);
        void Remove(Student student);
    }
}
