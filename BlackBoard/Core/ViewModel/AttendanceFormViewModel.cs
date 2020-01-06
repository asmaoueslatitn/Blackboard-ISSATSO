using System;
using System.ComponentModel.DataAnnotations;

namespace BlackBoard.Core.ViewModel
{
    public class AttendanceFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ExamRemarks { get; set; }

        [Required]
        [StringLength(255)]
        public string Interpretation { get; set; }

        public string SecondInterpretation { get; set; }
        public string ThirdInterpretation { get; set; }

        [Required]
        public string RecoverCandidate { get; set; }


        public DateTime Date { get; set; }

        public string Heading { get; set; }

        [Required]
        public int Student { get; set; }


        [Required]
        public int Teacher { get; set; }


        //public DateTime GetDate()
        //{
        //    return DateTime.Parse(string.Format("{0}", Date));
        //}
    }
}