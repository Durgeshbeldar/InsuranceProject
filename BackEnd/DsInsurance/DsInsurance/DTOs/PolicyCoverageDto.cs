using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyCoverageDto
    {
        public Guid? CoverageId { get; set; }

        [Required(ErrorMessage = "Policy Number is required.")]
        public Guid? PolicyNo { get; set; }

        [Required(ErrorMessage = "Coverage Type is required.")]
        [StringLength(50, ErrorMessage = "Coverage Type cannot exceed 50 characters.")]
        public string CoverageType { get; set; }

        [Required(ErrorMessage = "Coverage Limit is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Coverage Limit must be a positive value.")]
        public decimal CoverageLimit { get; set; }

        [Required(ErrorMessage = "Deductible Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Deductible Amount must be a positive value.")]
        public decimal DeductibleAmount { get; set; }

        [Required(ErrorMessage = "Premium Impact is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Premium Impact must be a positive value.")]
        public decimal PremiumImpact { get; set; }

    }
}
