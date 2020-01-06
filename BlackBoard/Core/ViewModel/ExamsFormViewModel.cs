using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.ViewModel
{
    public class ExamFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [ValidDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }


        [Required]
        public string Detail { get; set; }

        [Required]
        public bool Status { get; set; }


        [Required]
        public int Student { get; set; }
        public IEnumerable<Student> Students { get; set; }

        [Required]
        public int Teacher { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public string Heading { get; set; }

        public IEnumerable<Exam> Exams { get; set; }


        public DateTime GetStartDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }


        //public string Action
        //{
        //    get
        //    {
        //        Expression<Func<ExamsController, ActionResult>> update = (c => c.Update(this));
        //        Expression<Func<ExamsController, ActionResult>> create = (c => c.Create(this));
        //        var action = (Id != 0) ? update : create;
        //        return (action.Body as MethodCallExpression).Method.Name;
        //    }
        //}

    }
}