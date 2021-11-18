using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly CategoriesService service;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(CategoriesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<UpdateCategoryCommand, Category>(request);
            var updatedCategoryEntity = await service.UpdateCategoryAsync(category);
            var updatedCategoryModel = mapper.Map<Category, CategoryModel>(updatedCategoryEntity);
            var response = new CommandResponse<CategoryModel>(updatedCategoryModel, "Category have been updated successfully.");

            return response;
        }
    }
}
