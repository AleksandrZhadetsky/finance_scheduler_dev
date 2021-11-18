using Domain.Models;
using System.Collections.Generic;

namespace Domain.Responses.Identity
{
    public class IdentityResponse
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public bool Succeeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public IdentityResponse(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public IdentityResponse(UserModel user, string token, bool succeeded)
        {
            User = user;
            Token = token;
            Succeeded = succeeded;
        }

        public IdentityResponse(UserModel user, string token, bool succeeded, IEnumerable<string> errors) : this(user, token, succeeded)
        {
            Errors = errors;
        }
    }
}
