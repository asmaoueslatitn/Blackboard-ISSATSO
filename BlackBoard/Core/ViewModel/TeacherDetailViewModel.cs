using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.ViewModel
{
    public class TeacherDetailViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Exam> UpcomingExams { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}