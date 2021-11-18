using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Categories.Delete
{
    public class DeleteCategoryCommand : IRequest<CommandResponse<CategoryModel>>
    {
        public string Id { get; set; }
    }
}
