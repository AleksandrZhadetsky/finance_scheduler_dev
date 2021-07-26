using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Identity
{
    public class IdentityResponse
    {
        public AppUser User { get; set; }

        public string Token { get; set; }

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public IdentityResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public IdentityResponse(AppUser user, string token, bool succeeded)
        {
            User = user;
            Token = token;
            Succeeded = succeeded;
        }

        public IdentityResponse(AppUser user, string token, bool succeeded, string message) : this(user, token, succeeded)
        {
            Message = message;
        }
    }
}
