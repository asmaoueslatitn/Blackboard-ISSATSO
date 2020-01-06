using System.Data.Entity.ModelConfiguration;
using BlackBoard.Core.Models;

namespace BlackBoard.Persistence.EntityConfigurations
{
    public class SpecializationConfiguration : EntityTypeConfiguration<Specialization>
    {
        public SpecializationConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}