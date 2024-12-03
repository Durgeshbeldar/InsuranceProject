using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class RefundRequestDto
    {
        public Guid? RefundRequestId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Request amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Request amount must be positive.")]
        public decimal RequestAmount { get; set; }

        [Required(ErrorMessage = "Refund reason is required.")]
        [StringLength(200, ErrorMessage = "Reason cannot exceed 200 characters.")]
        public string RefundReason { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Initiated date is required.")]
        public DateTime InitiatedDate { get; set; }

        public Guid? ReviewedBy { get; set; }

        public DateTime? ReviewedDate { get; set; }
    }
}
