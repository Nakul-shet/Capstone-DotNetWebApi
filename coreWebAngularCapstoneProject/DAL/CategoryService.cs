using coreWebAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace coreWebAngularCapstoneProject.DAL
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDBContext _context;

        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _context.Categories.FromSqlRaw<Category>("GetAllCetegory").ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int id)
        {
            var param = new SqlParameter("@CategoryId", id);

            var productDetails = await Task.Run(() => _context.Categories
            .FromSqlRaw(@"exec GetCategoryById @CategoryId", param).ToListAsync()
            );

            return productDetails;
        }

        public async Task<IEnumerable<Category>> GetCategoryNameByIdAsync(int id)
        {
            var param = new SqlParameter("@CategoryId", id);

            var productDetails = await Task.Run(() => _context.Categories
            .FromSqlRaw(@"exec GetCategoryName @CategoryId", param).ToListAsync()
            );

            return productDetails;
        }
        public async Task<int> AddCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.CategoryDescription));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec AddNewCategory @CategoryName,
            @CategoryDescription
            ",
           parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateCategoryById(int id, Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryId", id));
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.CategoryDescription));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec UpdateCategoryById @CategoryId ,@CategoryName,
            @CategoryDescription
            ",
            parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteCategoryById(int id)
        {
            var param = new SqlParameter("@CategoryId", id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteCategoryById @CategoryId", param)
            );

            return result;
        }

    }
}
