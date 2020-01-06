using System;
using System.Collections.Generic;
using System.Linq;
using BlackBoard.Core.Models;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Core.Repositories
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetExams();
        IEnumerable<Exam> GetExamWithStudent(int id);
        IEnumerable<Exam> GetExamByTeacher(int id);
        IEnumerable<Exam> GetTodaysExams(int id);
        IEnumerable<Exam> GetUpcommingExams(string userId);
        IEnumerable<Exam> GetDaillyExams(DateTime getDate);
        IQueryable<Exam> FilterExams(ExamSearchVM searchModel);
        bool ValidateExam(DateTime appntDate, int id);
        int CountExams(int id);
        Exam GetExam(int id);
        void Add(Exam exam);

    }
}