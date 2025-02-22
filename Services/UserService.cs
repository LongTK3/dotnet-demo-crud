using UserManagementAPI.Models;
using UserManagementAPI.UnitOfWork;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ZipCode = user.ZipCode
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAllUsers();
            return users.Select(u => MapToUserDto(u));
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await _unitOfWork.Users.GetUserById(id);
            return user == null ? null : MapToUserDto(user);
        }

        public async Task<User> AddUser(User user)
        {
            await _unitOfWork.Users.AddUser(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            var existingUser = await _unitOfWork.Users.GetUserById(id);
            if (existingUser == null) return null;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.ZipCode = user.ZipCode;

            _unitOfWork.Users.UpdateUser(existingUser);
            await _unitOfWork.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetUserById(id);
            if (user == null) return false;

            _unitOfWork.Users.DeleteUser(user);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
