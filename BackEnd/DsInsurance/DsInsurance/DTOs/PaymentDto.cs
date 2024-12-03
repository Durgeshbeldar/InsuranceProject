using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PaymentDto
    {
        public Guid? PaymentId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Payment amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Payment amount must be positive.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }
    }
}
