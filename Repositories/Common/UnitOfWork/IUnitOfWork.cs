using UserManagementAPI.Repositories.Interfaces;

namespace UserManagementAPI.Repositories.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
