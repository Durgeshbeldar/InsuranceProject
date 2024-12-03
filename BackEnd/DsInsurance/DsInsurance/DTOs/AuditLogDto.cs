using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AuditLogDto
    {
        public Guid? AuditId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Action type is required.")]
        [StringLength(50, ErrorMessage = "Action type cannot exceed 50 characters.")]
        public string ActionType { get; set; }

        public string? ActionDetails { get; set; }

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; }
    }
}
