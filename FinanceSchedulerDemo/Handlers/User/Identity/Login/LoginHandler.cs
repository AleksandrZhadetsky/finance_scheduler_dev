using Domain.User;
using Domain.User.Identity;
using Handlers.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.User.Identity.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, IdentityResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerator tokenGenerator;
        //private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration config;

        public LoginHandler(
            UserManager<AppUser> userManager,
            TokenGenerator tokenGenerator,
            //SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config
        )
        {
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
            //this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.config = config;
        }

        public async Task<IdentityResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            AppUser user = await userManager.FindByNameAsync(request.UserName);

            if (user is not null && (await userManager.CheckPasswordAsync(user, request.Password)) is true)
            {
                var token = await tokenGenerator.GetTokenAsync(user);

                return new IdentityResponse(user, token, true);
            }

            return new IdentityResponse(false, "User with the same credentials already exists or password is invalid");
        }
    }
}
