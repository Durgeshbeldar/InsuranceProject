using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class WithdrawalRequest
    {
        [Key]
        public Guid WithdrawalRequestId { get; set; }

        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Pending, Approved, Rejected

        [Required]
        public DateTime RequestDate { get; set; }

        // Navigation Properties
        public Agent Agent { get; set; }
    }
}
