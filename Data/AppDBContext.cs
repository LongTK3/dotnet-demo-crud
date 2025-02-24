using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManagementAPI.Data.SeedData;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Seed();
        }
    }
}
