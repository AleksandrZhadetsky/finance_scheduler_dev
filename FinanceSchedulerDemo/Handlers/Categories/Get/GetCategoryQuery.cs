using Domain.Models;
using Domain.Responses;
using MediatR;

namespace Handlers.Categories.Get
{
    public class GetCategoryQuery : IRequest<CommandResponse<CategoryModel>>
    {
        public string Id { get; set; }
    }
}
