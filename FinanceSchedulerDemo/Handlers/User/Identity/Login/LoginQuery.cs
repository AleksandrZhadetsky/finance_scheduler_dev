using Domain.Responses.Identity;
using MediatR;

namespace Handlers.User.Identity.Login
{
    public class LoginQuery : IRequest<IdentityResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
