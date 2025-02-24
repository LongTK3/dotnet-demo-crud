using UserManagementAPI.Data;
using UserManagementAPI.Repositories.Interfaces;

namespace UserManagementAPI.Repositories.Common.UnitOfWork
{
    public class UnitOfWork(AppDbContext context, IUserRepository userRepository) : IUnitOfWork
    {
        public IUserRepository Users { get; } = userRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
