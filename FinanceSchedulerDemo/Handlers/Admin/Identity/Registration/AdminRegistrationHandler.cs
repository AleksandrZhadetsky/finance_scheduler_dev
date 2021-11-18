using AutoMapper;
using Domain.Models;
using Domain.Responses.Identity;
using Domain.Roles;
using Domain.User;
using Handlers.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Admin.Identity.Registration
{
    public class AdminRegistrationHandler : IRequestHandler<AdminRegistrationCommand, IdentityResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerator tokenGenerator;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminRegistrationHandler(
            IMapper mapper,
            UserManager<AppUser> userManager,
            TokenGenerator tokenGenerator,
            RoleManager<IdentityRole> roleManager
        )
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResponse> Handle(AdminRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userExists = await userManager.FindByNameAsync(request.UserName);
            var errors = new List<string>();

            if (userExists is not null)
            {
                errors.Add("User with the same credentials already exists");

                return new IdentityResponse(false, errors);
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
                errors = authResult.Errors.Select(e => e.Description).ToList();

                return new IdentityResponse(false, errors);
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
            var userModel = mapper.Map<AppUser, UserModel>(user);

            return new IdentityResponse(userModel, token, true);
        }
    }
}
