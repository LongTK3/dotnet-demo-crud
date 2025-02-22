using System.Threading.Tasks;
using UserManagementAPI.Data;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        public IUserRepository Users { get; }

        public UnitOfWork(AppDBContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
