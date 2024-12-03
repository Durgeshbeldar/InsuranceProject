using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class ReinsuranceContractDto
    {
        public Guid? ReinsuranceId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Reinsurer name is required.")]
        [StringLength(100, ErrorMessage = "Reinsurer name cannot exceed 100 characters.")]
        public string ReinsurerName { get; set; }

        [Required(ErrorMessage = "Coverage percentage is required.")]
        [Range(0, 100, ErrorMessage = "Coverage percentage must be between 0 and 100.")]
        public float CoveragePercentage { get; set; }

        [Required(ErrorMessage = "Contract terms are required.")]
        public string ContractTerms { get; set; }
    }
}
