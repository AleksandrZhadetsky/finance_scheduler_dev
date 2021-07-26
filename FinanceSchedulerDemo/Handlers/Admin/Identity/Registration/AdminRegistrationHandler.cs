using Domain.Roles;
using Domain.User;
using Domain.User.Identity;
using Handlers.Security;
using Handlers.User.Identity.Registration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Admin.Identity.Registration
{
    public class AdminRegistrationHandler : IRequestHandler<AdminRegistrationCommand, IdentityResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerator tokenGenerator;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration config;

        public AdminRegistrationHandler(
            UserManager<AppUser> userManager,
            TokenGenerator tokenGenerator,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config
        )
        {
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
            this.roleManager = roleManager;
            this.config = config;
        }

        public async Task<IdentityResponse> Handle(AdminRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userExists = await userManager.FindByNameAsync(request.UserName);
            if (userExists is not null)
            {
                return new IdentityResponse(false, "user with the same credentials already exists");
            }

            var user =
                new AppUser(
                    email: request.Email,
                    userName: request.UserName,
                    securityStamp: Guid.NewGuid().ToString()
                 );

            var authResult = await userManager.CreateAsync(user, request.Password);

            if (!authResult.Succeeded)
            {
                return new IdentityResponse(false, "registration failed");
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.AdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.AdminRole));
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.UserRole))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.UserRole));
            }

            await userManager.AddToRoleAsync(user, UserRoles.UserRole);
            await userManager.AddToRoleAsync(user, UserRoles.AdminRole);

            var token = await tokenGenerator.GetTokenAsync(user);

            return new IdentityResponse(user, token, true);
        }
    }
}
