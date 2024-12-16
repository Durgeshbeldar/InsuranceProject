using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class InstallmentDto
    {
        public Guid? InstallmentId { get; set; } // Nullable for creation

        [Required(ErrorMessage = "Policy number is required.")]
        public Guid? PolicyNo { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Amount due is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount due must be greater than zero.")]
        public decimal AmountDue { get; set; }
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = "Pending";
    }
}
