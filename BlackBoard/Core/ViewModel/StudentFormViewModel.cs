using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using BlackBoard.Controllers;
using BlackBoard.Core.Helpers;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.ViewModel
{
    public class StudentFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public Naming Name { get; set; }
      
        public Division DivisionD { get; set; }
        public Level LevelG { get; set; }
        [Required]
        [ValidDate]
        public string SemesterDate { get; set; }


      
        [Required]
       

        public byte Department { get; set; }

        public DateTime Date { get; set; }

        public string Heading { get; set; }

        public DateTime GetBirthDate()
        {
            //TODO: Validate SemesterDate 

            return DateTime.Parse(string.Format("{0}", SemesterDate));
            //return DateTime.ParseExact(SemesterDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }

        public IEnumerable<Department> Departments { get; set; }



        public string Action
        {
            get
            {
                Expression<Func<StudentsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<StudentsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        #region for dropdownlist

        public IEnumerable<SelectListItem> DivisionsList
        {
            get { return ClinicMgtHelpers.DivisionToSelectList(); }
            set { }
        }
        public IEnumerable<SelectListItem> LevelsList
        {
            get { return ClinicMgtHelpers.LevelToSelectList(); }
            set { }
        }
        public IEnumerable<SelectListItem> NamesList
        {
            get { return ClinicMgtHelpers.NameToSelectList(); }
            set { }
        }
        #endregion
    }
}