using Microsoft.AspNetCore.Identity;

namespace Domain.User
{
    public class AppUser : IdentityUser
    {
        public double Balance { get; set; }

        public AppUser()
        {
        }

        public AppUser(string email, string username)
        {
            Email = email;
            UserName = username;
        }

        public AppUser(string email, string userName, string securityStamp) : this(email, userName)
        {
            SecurityStamp = securityStamp;
        }
    }
}
