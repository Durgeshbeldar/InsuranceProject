using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class RefundRequest
    {
        [Key]
        public Guid RefundRequestId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        public decimal RequestAmount { get; set; }

        [Required]
        [StringLength(200)]
        public string RefundReason { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Pending, Approved, Rejected

        [Required]
        public DateTime InitiatedDate { get; set; }

        [ForeignKey("Employee")]
        public int? ReviewedBy { get; set; } // Nullable, assigned when reviewed

        public DateTime? ReviewedDate { get; set; }

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
