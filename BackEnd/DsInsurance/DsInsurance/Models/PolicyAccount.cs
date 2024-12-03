using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class PolicyAccount
    {
        [Key]
        public Guid PolicyNo { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        [ForeignKey("InsuranceScheme")]
        public int InsuranceSchemeId { get; set; }

        [Required]
        public decimal SumAssured { get; set; }

        [Required]
        public string PremiumType { get; set; } // Enum: Monthly, Quarterly, Yearly

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime MaturityDate { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Active, Lapsed, Surrendered

        // Navigation Properties
        public Customer Customer { get; set; }
        public Agent Agent { get; set; }
        public InsuranceScheme InsuranceScheme { get; set; }
    }
}
