using System.Data.Entity.ModelConfiguration;
using BlackBoard.Core.Models;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class StudentStatusConfiguration : EntityTypeConfiguration<StudentStatus>
    {
        public StudentStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}