using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyTransactionDto
    {
        public Guid? TransactionId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Transaction type is required.")]
        public string TransactionType { get; set; }

        [Required(ErrorMessage = "Transaction date is required.")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Transaction amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive.")]
        public decimal Amount { get; set; }

        public string? Description { get; set; }
    }
}
