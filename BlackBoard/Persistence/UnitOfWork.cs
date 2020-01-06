using BlackBoard.Core;
using BlackBoard.Core.Repositories;
using BlackBoard.Persistence.Repositories;

namespace BlackBoard.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; private set; }
        public IExamRepository Exams { get; private set; }
        public IAttendanceRepository Attandences { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
            Exams = new ExamRepository(context);
            Attandences = new AttendanceRepository(context);
            Departments = new DepartmentRepository(context);
            Teachers = new TeacherRepository(context);
            Specializations = new SpecializationRepository(context);
            Users = new ApplicationUserRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}