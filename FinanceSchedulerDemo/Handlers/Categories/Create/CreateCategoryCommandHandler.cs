using AutoMapper;
using Domain.Categories;
using Domain.Models;
using Domain.Responses;
using MediatR;
using Services.Categories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Handlers.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommandResponse<CategoryModel>>
    {
        private readonly CategoriesService service;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(CategoriesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<CommandResponse<CategoryModel>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<CreateCategoryCommand, Category>(request);

            try
            {
                var createdCategory = await service.CreateCategoryAsync(category);
                var categoryModel = mapper.Map<Category, CategoryModel>(createdCategory);
                var response = new CommandResponse<CategoryModel>(categoryModel, "Category have been created successfully.");

                return response;
            }
            catch (Exception)
            {
                return new CommandResponse<CategoryModel>("Category creation failed.");
            }
        }
    }
}
