using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Get
{
    public class RetrieveCategoryCommandHandler : IRequestHandler<GetCategoryQuery, CommandResponse<CategoryModel>>
    {
        private readonly CategoriesService service;
        private readonly IMapper mapper;

        public RetrieveCategoryCommandHandler(CategoriesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await service.GetCategoryAsync(request.Id);
            var categoryModel = mapper.Map<Category, CategoryModel>(category);
            var response = new CommandResponse<CategoryModel>(categoryModel, "Category have been retrieved successfully.");

            return response;
        }
    }
}
