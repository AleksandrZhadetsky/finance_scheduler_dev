using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Categories.Update
{
    public class UpdateCategoryCommand : IRequest<CommandResponse<CategoryModel>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
