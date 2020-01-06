using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlackBoard.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public Naming Name { get; set; }
        public Division DivisionD { get; set; }
        public Level LevelG { get; set; }
        public DateTime SemesterDate { get; set; }
       
        public byte DepartmentId { get; set; }
        public Department Departments { get; set; }
        public DateTime DateTime { get; set; }
       

        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - SemesterDate.Year;
                if (SemesterDate > now.AddYears(-age)) age--;
                return age;
            }

        }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

        public Student()
        {
            Exams = new Collection<Exam>();
            Attendances = new Collection<Attendance>();
        }
    }
}