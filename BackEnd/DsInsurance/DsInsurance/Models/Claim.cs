using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DsInsurance.Models
{
    public class Claim
    {
        [Key]
        public Guid ClaimId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; } // Nullable for cases where no employee is assigned

        [Required]
        [StringLength(200)]
        public string ClaimReason { get; set; }

        [Required]
        public DateTime IncidentDate { get; set; }

        public string IncidentDescription { get; set; }

        [ForeignKey("Document")]
        public int SupportingDocumentId { get; set; }

        [Required]
        public decimal ClaimAmount { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Submitted, In Progress, Approved, Rejected

        public decimal? SettlementAmount { get; set; }

        public DateTime? ApprovalDate { get; set; }

        // Navigation Properties
        // New Navigation Property for Riders
        public ICollection<PolicyRider> ApplicableRiders { get; set; }
        public PolicyAccount PolicyAccount { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Document SupportingDocument { get; set; }
    }
}
