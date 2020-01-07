using System.Data.Entity.ModelConfiguration;
using BlackBoard.Core.Models;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
        }
    }
}