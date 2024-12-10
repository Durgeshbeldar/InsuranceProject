using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyTransactionDto
    {
        public Guid? TransactionId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public Guid? PolicyNo { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        [StringLength(50, ErrorMessage = "Transaction type cannot exceed 50 characters.")]
        public string TransactionType { get; set; } // Enum: Issuance, Renewal, Cancellation, Refund

        [Required(ErrorMessage = "Transaction date is required.")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        public string? Description { get; set; }
    }
}
