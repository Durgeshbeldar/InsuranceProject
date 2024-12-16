using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AgentDto
    {
        [Required(ErrorMessage = "Agent ID (User ID) is required.")]
        public Guid AgentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }
        public Guid? AddressId { get; set; }

        public bool? KycVerified { get; set; } = false;

        public string? AddressDetails { get; set; }

        public decimal? TotalCommission { get; set; } = 0;

        public decimal? WalletBalance { get; set; } = 0;

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float? Rating { get; set; } = 0;

        public DateTime? ActiveSince { get; set; } = DateTime.UtcNow;
    }
}
