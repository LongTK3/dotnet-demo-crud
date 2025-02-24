using UserManagementAPI.Dtos;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;
using UserManagementAPI.Repositories.Common.UnitOfWork;

namespace UserManagementAPI.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private static UserDto MapToUserDto(User user)
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
            var users = await unitOfWork.Users.GetAllUsers();
            return users.Select(MapToUserDto);
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await unitOfWork.Users.GetUserById(id);
            return user == null ? null : MapToUserDto(user);
        }

        public async Task<User> AddUser(User user)
        {
            await unitOfWork.Users.AddUser(user);
            await unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            var existingUser = await unitOfWork.Users.GetUserById(id);
            if (existingUser == null) return null;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.ZipCode = user.ZipCode;

            unitOfWork.Users.UpdateUser(existingUser);
            await unitOfWork.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await unitOfWork.Users.GetUserById(id);
            if (user == null) return false;

            unitOfWork.Users.DeleteUser(user);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
