using BlackBoard.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class ExamConfiguration : EntityTypeConfiguration<Exam>
    {
        public ExamConfiguration()
        {
            Property(a => a.StudentId).IsRequired();
            Property(a => a.TeacherId).IsRequired();
            Property(a => a.StartDateTime).IsRequired();
            Property(a => a.Detail).IsRequired();
            Property(a => a.Status).IsRequired();
        }
    }
}