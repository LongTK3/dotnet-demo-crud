namespace UserManagementAPI.Dtos
{
    public class UserDto
    {
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ZipCode { get; set; }
    }
}
