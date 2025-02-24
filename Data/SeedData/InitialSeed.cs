using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data.SeedData;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
           new
                        {
                            Id = 1,
                            Email = "an.nguyen@example.com",
                            FirstName = "Nguyễn",
                            LastName = "Văn An",
                            PhoneNumber = "0912345678",
                            ZipCode = "700000"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bich.tran@example.com",
                            FirstName = "Trần",
                            LastName = "Thị Bích",
                            PhoneNumber = "0987654321",
                            ZipCode = "100000"
                        },
                        new
                        {
                            Id = 3,
                            Email = "hung.pham@example.com",
                            FirstName = "Phạm",
                            LastName = "Thanh Hùng",
                            PhoneNumber = "0905123456",
                            ZipCode = "550000"
                        },
                        new
                        {
                            Id = 4,
                            Email = "nhung.le@example.com",
                            FirstName = "Lê",
                            LastName = "Hồng Nhung",
                            PhoneNumber = "0933123456",
                            ZipCode = "600000"
                        },
                        new
                        {
                            Id = 5,
                            Email = "tuan.dang@example.com",
                            FirstName = "Đặng",
                            LastName = "Minh Tuấn",
                            PhoneNumber = "0922123456",
                            ZipCode = "300000"
                        },
                        new
                        {
                            Id = 6,
                            Email = "mai.bui@example.com",
                            FirstName = "Bùi",
                            LastName = "Thị Mai",
                            PhoneNumber = "0978899001",
                            ZipCode = "120000"
                        },
                        new
                        {
                            Id = 7,
                            Email = "anh.hoang@example.com",
                            FirstName = "Hoàng",
                            LastName = "Anh Tuấn",
                            PhoneNumber = "0967788992",
                            ZipCode = "150000"
                        },
                        new
                        {
                            Id = 8,
                            Email = "huy.vu@example.com",
                            FirstName = "Vũ",
                            LastName = "Quang Huy",
                            PhoneNumber = "0911223344",
                            ZipCode = "250000"
                        },
                        new
                        {
                            Id = 9,
                            Email = "lan.ly@example.com",
                            FirstName = "Lý",
                            LastName = "Thị Lan",
                            PhoneNumber = "0933445566",
                            ZipCode = "400000"
                        },
                        new
                        {
                            Id = 10,
                            Email = "cong.do@example.com",
                            FirstName = "Đỗ",
                            LastName = "Thành Công",
                            PhoneNumber = "0944556677",
                            ZipCode = "350000"
                        }
        );
        
    }
}