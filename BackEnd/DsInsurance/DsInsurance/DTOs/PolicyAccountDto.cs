using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyAccountDto
    {
        public Guid? PolicyNo { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Agent ID is required.")]
        public Guid AgentId { get; set; }

        [Required(ErrorMessage = "Insurance scheme ID is required.")]
        public Guid InsuranceSchemeId { get; set; }

        [Required(ErrorMessage = "Sum assured is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Sum assured must be a positive value.")]
        public decimal SumAssured { get; set; }

        [Required(ErrorMessage = "Premium type is required.")]
        public string PremiumType { get; set; }

        [Required(ErrorMessage = "Issue date is required.")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Maturity date is required.")]
        public DateTime MaturityDate { get; set; }

        [Required(ErrorMessage = "Policy status is required.")]
        public string Status { get; set; }
    }
}
