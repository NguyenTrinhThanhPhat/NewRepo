using Microsoft.AspNetCore.Identity;

namespace BigSchool.Controllers.Api
{
    internal class UserStore<T> : IUserStore<ApplicationUser>
    {
        public UserStore(ApplicationDbContext applicationDbContext)
        {
        }
    }
}