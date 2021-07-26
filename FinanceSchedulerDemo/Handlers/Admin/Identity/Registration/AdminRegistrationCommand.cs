using Domain.User;
using Domain.User.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Admin.Identity.Registration
{
    public class AdminRegistrationCommand : IRequest<IdentityResponse>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
