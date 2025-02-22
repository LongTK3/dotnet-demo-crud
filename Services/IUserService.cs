using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto?> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
