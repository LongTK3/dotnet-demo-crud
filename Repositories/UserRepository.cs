using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories.Interfaces;

namespace UserManagementAPI.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUser(User user)
        {
            await context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
        }
    }
}
