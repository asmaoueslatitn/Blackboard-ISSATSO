using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.ViewModel
{
    public class StudentDetailViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public int CountExams { get; set; }
        public int CountAttendance { get; set; }
    }
}