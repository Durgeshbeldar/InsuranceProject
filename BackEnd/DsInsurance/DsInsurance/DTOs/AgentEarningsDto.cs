using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AgentEarningsDto
    {
        public Guid? EarningId { get; set; }

        [Required(ErrorMessage = "Agent ID is required.")]
        public int AgentId { get; set; }

        [Required(ErrorMessage = "Policy Number is required.")]
        public Guid PolicyNo { get; set; }

        public int? RiderId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Issued date is required.")]
        public DateTime IssuedAt { get; set; }
    }
}
