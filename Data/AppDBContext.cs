using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Bảng Users trong database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Validation Rules
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.PhoneNumber)
                .HasMaxLength(15);

            modelBuilder.Entity<User>()
                .Property(u => u.ZipCode)
                .HasMaxLength(10);

            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Nguyễn", LastName = "Văn An", Email = "an.nguyen@example.com", PhoneNumber = "0912345678", ZipCode = "700000" },
            new User { Id = 2, FirstName = "Trần", LastName = "Thị Bích", Email = "bich.tran@example.com", PhoneNumber = "0987654321", ZipCode = "100000" },
            new User { Id = 3, FirstName = "Phạm", LastName = "Thanh Hùng", Email = "hung.pham@example.com", PhoneNumber = "0905123456", ZipCode = "550000" },
            new User { Id = 4, FirstName = "Lê", LastName = "Hồng Nhung", Email = "nhung.le@example.com", PhoneNumber = "0933123456", ZipCode = "600000" },
            new User { Id = 5, FirstName = "Đặng", LastName = "Minh Tuấn", Email = "tuan.dang@example.com", PhoneNumber = "0922123456", ZipCode = "300000" },
            new User { Id = 6, FirstName = "Bùi", LastName = "Thị Mai", Email = "mai.bui@example.com", PhoneNumber = "0978899001", ZipCode = "120000" },
            new User { Id = 7, FirstName = "Hoàng", LastName = "Anh Tuấn", Email = "anh.hoang@example.com", PhoneNumber = "0967788992", ZipCode = "150000" },
            new User { Id = 8, FirstName = "Vũ", LastName = "Quang Huy", Email = "huy.vu@example.com", PhoneNumber = "0911223344", ZipCode = "250000" },
            new User { Id = 9, FirstName = "Lý", LastName = "Thị Lan", Email = "lan.ly@example.com", PhoneNumber = "0933445566", ZipCode = "400000" },
            new User { Id = 10, FirstName = "Đỗ", LastName = "Thành Công", Email = "cong.do@example.com", PhoneNumber = "0944556677", ZipCode = "350000" }
        );
        }
    }


}
