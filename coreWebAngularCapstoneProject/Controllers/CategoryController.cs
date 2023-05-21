using coreWebAngularCapstoneProject.DAL;
using coreWebAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreWebAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService medicineService)
        {
            _categoryService = medicineService;
        }

        [EnableCors]
        [HttpGet("GetAllCetegory")]
        public async Task<List<Category>> GetCategoryListAsync()
        {
            try
            {
                return await _categoryService.GetCategoryListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpGet("GetCategoryById")]
        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int Id)
        {
            try
            {
                var response = await _categoryService.GetCategoryByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpGet("GetCategoryName")]
        public async Task<IEnumerable<Category>> GetCategoryNameByIdAsync(int Id)
        {
            try
            {
                var response = await _categoryService.GetCategoryNameByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpPost("AddNewCategory")]
        public async Task<int> AddNewCategoryAsync(Category category)
        {
            try
            {
                var response = await _categoryService.AddCategoryAsync(category);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpPut("UpdateCategoryById")]
        public async Task<int> UpdateProductByIdAsync(Category category, int id)
        {
            try
            {
                var response = await _categoryService.UpdateCategoryById(id , category);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpDelete("DeleteCategoryById")]
        public async Task<int> DeleteProductById(int id)
        {
            try
            {
                var response = await _categoryService.DeleteCategoryById(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
