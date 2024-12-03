using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Pending, Completed

        [Required]
        public DateTime PaymentDate { get; set; }

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
    }
}
