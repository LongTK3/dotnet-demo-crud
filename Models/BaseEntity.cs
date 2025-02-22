using System;

namespace UserManagementAPI.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
