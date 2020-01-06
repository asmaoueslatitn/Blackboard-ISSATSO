using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Dto
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public SpecializationDto Specialization { get; set; }
        public ICollection<Exam> Exams { get; set; }



    }
}