using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "an.nguyen@example.com", "Nguyễn", "Văn An", "0912345678", "700000" },
                    { 2, "bich.tran@example.com", "Trần", "Thị Bích", "0987654321", "100000" },
                    { 3, "hung.pham@example.com", "Phạm", "Thanh Hùng", "0905123456", "550000" },
                    { 4, "nhung.le@example.com", "Lê", "Hồng Nhung", "0933123456", "600000" },
                    { 5, "tuan.dang@example.com", "Đặng", "Minh Tuấn", "0922123456", "300000" },
                    { 6, "mai.bui@example.com", "Bùi", "Thị Mai", "0978899001", "120000" },
                    { 7, "anh.hoang@example.com", "Hoàng", "Anh Tuấn", "0967788992", "150000" },
                    { 8, "huy.vu@example.com", "Vũ", "Quang Huy", "0911223344", "250000" },
                    { 9, "lan.ly@example.com", "Lý", "Thị Lan", "0933445566", "400000" },
                    { 10, "cong.do@example.com", "Đỗ", "Thành Công", "0944556677", "350000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
