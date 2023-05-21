using coreWebAngularCapstoneProject.Models;

namespace coreWebAngularCapstoneProject.DAL
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryListAsync();

        public Task<IEnumerable<Category>> GetCategoryByIdAsync(int id);

        public Task<IEnumerable<Category>> GetCategoryNameByIdAsync(int id);

        public Task<int> AddCategoryAsync(Category category);

        public Task<int> UpdateCategoryById(int id, Category category);

        public Task<int> DeleteCategoryById(int id);
    }
}
