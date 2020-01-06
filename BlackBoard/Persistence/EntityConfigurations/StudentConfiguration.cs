using System.Data.Entity.ModelConfiguration;
using BlackBoard.Core.Models;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(p => p.DepartmentId).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.LevelG).IsRequired();
            Property(p => p.DivisionD).IsRequired();
            Property(p => p.SemesterDate).IsRequired();
            Property(p => p.Token).IsRequired();
            HasMany(p => p.Exams)
                .WithRequired(a => a.Student)
                .WillCascadeOnDelete(false);
        }
    }
}