using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class RefundTracking
    {
        [Key]
        public Guid RefundId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [ForeignKey("RefundRequest")]
        public int RefundRequestId { get; set; }

        [Required]
        public decimal RefundAmount { get; set; }

        [Required]
        public DateTime ProcessedDate { get; set; }

        [StringLength(200)]
        public string Comments { get; set; } // Optional comments on the refund processing

        [ForeignKey("PolicyTransaction")]
        public int PolicyTransactionId { get; set; }

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
        public RefundRequest RefundRequest { get; set; }
        public PolicyTransaction PolicyTransaction { get; set; }
    }
}
