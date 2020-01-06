using BlackBoard.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            Property(p => p.StudentId).IsRequired();
            Property(p => p.ExamRemarks).IsRequired();
            Property(p => p.Interpretation).IsRequired().HasMaxLength(255);
            Property(p => p.RecoverCandidate).IsRequired();
        }
    }
}