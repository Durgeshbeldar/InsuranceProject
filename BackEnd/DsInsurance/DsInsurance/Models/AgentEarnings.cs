using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class AgentEarnings
    {
        [Key]
        public Guid EarningId { get; set; }

        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [ForeignKey("PolicyRider")]
        public int RiderId { get; set; } // Link to the specific rider


        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Type { get; set; } // Enum: Registration, Installment

        [Required]
        public DateTime IssuedAt { get; set; }

        // Navigation Properties
        public Agent Agent { get; set; }
        public PolicyAccount PolicyAccount { get; set; }
    }
}
