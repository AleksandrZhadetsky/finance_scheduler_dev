using Handlers.Categories.Create;
using Handlers.Categories.Delete;
using Handlers.Categories.Get;
using Handlers.Categories.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceSchedulerDemo.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var response = await mediator.Send(command);

            return Created("", response);
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetCategory(GetCategoryQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
