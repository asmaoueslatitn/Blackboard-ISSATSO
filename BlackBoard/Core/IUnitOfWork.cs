using BlackBoard.Core.Repositories;

namespace BlackBoard.Core
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        IExamRepository Exams { get; }
        IAttendanceRepository Attandences { get; }
        IDepartmentRepository Departments { get; }
        ITeacherRepository Teachers { get; }
        ISpecializationRepository Specializations { get; }
        IApplicationUserRepository Users { get; }

        void Complete();
    }
}