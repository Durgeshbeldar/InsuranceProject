using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class InstallmentDto
    {
        public Guid? InstallmentId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public int PolicyNo { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required(ErrorMessage = "Amount due is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount due must be a positive value.")]
        public decimal AmountDue { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount paid must be a positive value.")]
        public decimal? AmountPaid { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }
}
