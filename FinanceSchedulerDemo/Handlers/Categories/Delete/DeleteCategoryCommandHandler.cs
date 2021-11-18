using AutoMapper;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly CategoriesService service;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(CategoriesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await service.DeleteCategoryAsync(request.Id);

            return new CommandResponse<CategoryModel>(null, "Category have been deletet successfully.");
        }
    }
}
