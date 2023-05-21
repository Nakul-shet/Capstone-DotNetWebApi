using coreWebAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace coreWebAngularCapstoneProject.DAL
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async  Task<int> CreateNewUser(User user)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@User", user.Name));
            parameter.Add(new SqlParameter("@UserName", user.UserName));
            parameter.Add(new SqlParameter("@UserPassword", user.Password));
            parameter.Add(new SqlParameter("@UserEmail", user.Email));
            parameter.Add(new SqlParameter("@UserRole", user.Role));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec CreateUser @User,
            @UserName,
            @UserPassword,
            @UserEmail,
            @UserRole
            ",
            parameter.ToArray()));

            return result;
        }

        public async Task<List<User>> GetUserListAsync()
        {
            return await _context.Users.FromSqlRaw<User>("GetAllUsers").ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUserByIdAsync(int id)
        {
            var param = new SqlParameter("@UserId", id);

            var productDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec GetUserById @UserId", param).ToListAsync()
            );

            return productDetails;
        }

        public async Task<IEnumerable<User>> GetUserByUsername(string name)
        {
            var param = new SqlParameter("@UserName", name);

            var productDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec GetUserByUsername @UserName", param).ToListAsync()
            );

            return productDetails;
        }

    }
}
