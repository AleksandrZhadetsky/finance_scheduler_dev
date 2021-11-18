using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Categories.Create
{
    public class CreateCategoryCommand : IRequest<CommandResponse<CategoryModel>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
