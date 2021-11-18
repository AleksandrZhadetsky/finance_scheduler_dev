using DAL.DataAccess;
using Domain.Categories;
using System.Threading.Tasks;

namespace Services.Categories
{
    public class CategoriesService
    {
        private readonly AuthDbContext context;

        public CategoriesService(AuthDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="id"> Model of type <see cref="string"/>. </param>
        /// <returns> Entity of type <see cref="Category"/>. </returns>
        public ValueTask<Category> GetCategoryAsync(string id)
        {
            var category = context.Categories.FindAsync(id);

            return category;
        }

        /// <summary>
        /// Method for creating the category.
        /// </summary>
        /// <param name="category"> Model of type <see cref="Category"/>. </param>
        /// <returns> Entity of type <see cref="Category"/>. </returns>
        public async ValueTask<Category> CreateCategoryAsync(Category category)
        {
            var createdCategory = (await context.Categories.AddAsync(category)).Entity;
            await context.SaveChangesAsync();

            return createdCategory;
        }

        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="id"> Model of type <see cref="string"/>. </param>
        /// <returns></returns>
        public async ValueTask DeleteCategoryAsync(string id)
        {
            var category = await context.Categories.FindAsync(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Method for retrieving specific category.
        /// </summary>
        /// <param name="category"> Model of type <see cref="Category"/>. </param>
        /// <returns> Entity of type <see cref="Category"/>. </returns>
        public async ValueTask<Category> UpdateCategoryAsync(Category category)
        {
            var updatedCategory = context.Categories.Update(category).Entity;
            await context.SaveChangesAsync();

            return updatedCategory;
        }
    }
}
