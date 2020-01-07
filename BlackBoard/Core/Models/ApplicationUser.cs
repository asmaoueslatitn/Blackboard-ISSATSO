using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlackBoard.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // we'll add custom user claims here
           
            return userIdentity;
        }
    }
}