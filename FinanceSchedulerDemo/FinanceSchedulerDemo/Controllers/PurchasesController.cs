using Handlers.Purchases.Create;
using Handlers.Purchases.Delete;
using Handlers.Purchases.Get;
using Handlers.Purchases.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceSchedulerDemo.Controllers
{
    [Route("purchases")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PurchasesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseCommand command)
        {
            var response = await mediator.Send(command);

            return Created("", response);
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetPurchase(GetPurchaseQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePurchase(UpdatePurchaseCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePurchase(DeletePurchaseCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
