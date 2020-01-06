using System.Collections.Generic;
using BlackBoard.Core.Models;
using BlackBoard.Core.ViewModel;

namespace BlackBoard.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}