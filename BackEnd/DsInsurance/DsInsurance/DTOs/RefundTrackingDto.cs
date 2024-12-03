using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class RefundTrackingDto
    {
        public Guid? RefundId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Refund request ID is required.")]
        public Guid RefundRequestId { get; set; }

        [Required(ErrorMessage = "Refund amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Refund amount must be positive.")]
        public decimal RefundAmount { get; set; }

        [Required(ErrorMessage = "Processed date is required.")]
        public DateTime ProcessedDate { get; set; }

        [StringLength(200, ErrorMessage = "Comments cannot exceed 200 characters.")]
        public string? Comments { get; set; }

        [Required(ErrorMessage = "Policy transaction ID is required.")]
        public Guid PolicyTransactionId { get; set; }
    }
}
