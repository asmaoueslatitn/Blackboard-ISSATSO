using System;

namespace BlackBoard.Core.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public DateTime SemesterDate { get; set; }
        public string  LevelG { get; set; }
        public string DivisionD { get; set; }
       
        public string Address { get; set; }
        public byte DepartmentId { get; set; }
        public DepartmentDto Departments { get; set; }
        public int TeacherId { get; set; }
        public TeacherDto Teacher { get; set; }

        public DateTime DateTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}