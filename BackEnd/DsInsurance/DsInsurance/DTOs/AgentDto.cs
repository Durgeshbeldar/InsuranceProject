using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AgentDto
    {
        public Guid? AgentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address ID is required.")]
        public int? AddressId { get; set; }

        public string? AddressDetails { get; set; }

        public decimal TotalCommission { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        public DateTime ActiveSince { get; set; }

        public ICollection<int>? PolicyAccountIds { get; set; }
    }
}
