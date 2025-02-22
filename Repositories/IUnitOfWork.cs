using System;
using System.Threading.Tasks;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
