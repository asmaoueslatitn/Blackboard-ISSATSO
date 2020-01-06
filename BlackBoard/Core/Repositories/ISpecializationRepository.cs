using System.Collections.Generic;
using BlackBoard.Core.Models;

namespace BlackBoard.Core.Repositories
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetSpecializations();
    }
}
