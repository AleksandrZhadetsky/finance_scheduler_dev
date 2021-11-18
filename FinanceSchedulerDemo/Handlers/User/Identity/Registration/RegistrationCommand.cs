using Domain.Responses.Identity;
using MediatR;

namespace Handlers.User.Identity.Registration
{
    public class RegistrationCommand : IRequest<IdentityResponse>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
