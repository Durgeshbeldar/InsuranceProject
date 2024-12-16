using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class WithdrawalRequestDto
    {
        public Guid? WithdrawalRequestId { get; set; }

        [Required(ErrorMessage = "Agent ID is required.")]
        public Guid AgentId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Request date is required.")]
        public DateTime RequestDate { get; set; }  = DateTime.Now;
    }
}
