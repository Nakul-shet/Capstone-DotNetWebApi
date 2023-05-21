using coreWebAngularCapstoneProject.Models;

namespace coreWebAngularCapstoneProject.DAL
{
    public interface IUserService
    {

        public Task<int> CreateNewUser(User user);

        public Task<List<User>> GetUserListAsync();

        public Task<IEnumerable<User>> GetUserByIdAsync(int id);

        public Task<IEnumerable<User>> GetUserByUsername(string name);

    }
}
