using System.Data.Entity.ModelConfiguration;
using BlackBoard.Core.Models;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            Property(d => d.PhysicianId).IsRequired();
            Property(d => d.SpecializationId).IsRequired();
            Property(d => d.Name).IsRequired().HasMaxLength(255);
            Property(d => d.Phone).IsRequired();
        }
    }
}