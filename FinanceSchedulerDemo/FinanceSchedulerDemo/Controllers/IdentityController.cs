using Domain.Roles;
using Handlers.Admin.Identity.Registration;
using Handlers.User.Identity.Login;
using Handlers.User.Identity.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("test")]
        [Authorize(Roles = UserRoles.AdminRole)]
        public IActionResult AuthTest()
        {
            return Ok("youre admin!");
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
