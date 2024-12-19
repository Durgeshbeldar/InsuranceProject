using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class WithdrawalRequest
    {
        [Key]
        public Guid WithdrawalRequestId { get; set; }

        [ForeignKey("Agent")]
        public Guid AgentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Enum: Pending, Approved, Rejected

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string? ResponseMessage { get; set; }

        // Navigation Properties
        public Agent? Agent { get; set; }
    }
}
