using Domain.Responses.Identity;
using MediatR;

namespace Handlers.Admin.Identity.Registration
{
    public class AdminRegistrationCommand : IRequest<IdentityResponse>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
