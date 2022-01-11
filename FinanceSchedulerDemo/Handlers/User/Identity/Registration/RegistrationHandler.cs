// <copyright file="RegistrationHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Domain.Responses.Identity;
using Domain.Roles;
using Domain.User;
using Handlers.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Handlers.User.Identity.Registration
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, IdentityResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly TokenGenerator tokenGenerator;
        private readonly RoleManager<IdentityRole> roleManager;

        public RegistrationHandler(
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

        public async Task<IdentityResponse> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            var userExists = await userManager.FindByNameAsync(command.UserName);
            var errors = new List<string>();
            if (userExists is not null)
            {
                errors.Add("User with the same credentials already exists");

                return new IdentityResponse(false, errors);
            }

            var user =
                new AppUser(
                    email: command.Email,
                    userName: command.UserName,
                    securityStamp: Guid.NewGuid().ToString()
                 );

            var authResult = await userManager.CreateAsync(user, command.Password);

            if (!authResult.Succeeded)
            {
                return new IdentityResponse(false, authResult.Errors.Select(e => e.Description).ToList());
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.UserRole))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.UserRole));
            }

            await userManager.AddToRoleAsync(user, UserRoles.UserRole);

            var token = await tokenGenerator.GetTokenAsync(user);
            var userModel = mapper.Map<AppUser, UserModel>(user);

            return new IdentityResponse(userModel, token, true);
        }
    }
}
