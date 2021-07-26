using Handlers.Admin.Identity.Registration;
using Handlers.User.Identity.Login;
using Handlers.User.Identity.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSchedulerDemo.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator mediator;

        public IdentityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> RegisterAsync(RegistrationCommand command)
        {
            var response = await mediator.Send(command);

            return Created("", response);
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> LoginAsync(LoginQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("admin-sign-up")]
        public async Task<IActionResult> RegisterAdminAsync(AdminRegistrationCommand command)
        {
            var response = await mediator.Send(command);

            return Created("", response);
        }
    }
}
