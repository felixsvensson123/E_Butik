using System.Security.Claims;
using System.Security.Principal;

namespace BlazorEcom.Server.Helpers
{
    public static class UserHelpers
    {
        public static async Task<ApplicationUser?> GetUserAsync(this HttpContext context, DataContext dataContext)
        {
            return await dataContext.Users.SingleAsync(u => u.UserName.ToLower() == context.User.Identity!.Name!.ToLower());
        }
    }
}
