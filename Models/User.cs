using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models  // Đảm bảo namespace đúng
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone, MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(10)]
        public string? ZipCode { get; set; }
    }
}
