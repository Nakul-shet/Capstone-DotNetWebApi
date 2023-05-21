using coreWebAngularCapstoneProject.DAL;
using coreWebAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreWebAngularCapstoneProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors]
        [HttpPost("CreateUser")]
        public async Task<int> CreateNewUser(User user)
        {
            try
            {
                var response = await _userService.CreateNewUser(user);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [HttpGet("GetAllUsers")]
        public async Task<List<User>> GetMedicineListAsync()
        {
            try
            {
                return await _userService.GetUserListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IEnumerable<User>> GetUserByIdAsync(int Id)
        {
            try
            {
                var response = await _userService.GetUserByIdAsync(Id);

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

        [HttpGet("GetUserByUsername")]
        public async Task<IEnumerable<User>> GetUserByNameAsync(string name)
        {
            try
            {
                var response = await _userService.GetUserByUsername(name);

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

    }
}
