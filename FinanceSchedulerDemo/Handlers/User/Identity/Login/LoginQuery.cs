using Domain.User;
using Domain.User.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.User.Identity.Login
{
    public class LoginQuery : IRequest<IdentityResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
