using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
