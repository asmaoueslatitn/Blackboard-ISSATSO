using System;

namespace BlackBoard.Core.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string ExamRemarks { get; set; }
        public string Interpretation { get; set; }
        public string SecondInterpretation { get; set; }
        public string ThirdInterpretation { get; set; }
        public string RecoverCandidate { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

}