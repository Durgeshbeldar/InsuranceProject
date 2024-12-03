using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyCoverageDto
    {
        public Guid? CoverageId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Coverage type is required.")]
        [StringLength(50, ErrorMessage = "Coverage type cannot exceed 50 characters.")]
        public string CoverageType { get; set; }

        [Required(ErrorMessage = "Coverage limit is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Coverage limit must be positive.")]
        public decimal CoverageLimit { get; set; }

        [Required(ErrorMessage = "Deductible amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Deductible amount must be positive.")]
        public decimal DeductibleAmount { get; set; }

        [Required(ErrorMessage = "Premium impact is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Premium impact must be positive.")]
        public decimal PremiumImpact { get; set; }
    }
}
