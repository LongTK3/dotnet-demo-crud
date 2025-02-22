using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
