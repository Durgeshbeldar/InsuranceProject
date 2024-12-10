using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class InsuranceSchemeDto
    {
        public Guid? SchemeId { get; set; }

        [Required(ErrorMessage = "Plan Id is required.")]
        public Guid PlanId { get; set; }

        [Required(ErrorMessage = "Scheme name is required.")]
        [StringLength(100, ErrorMessage = "Scheme name cannot exceed 100 characters.")]
        public string SchemeName { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Minimum amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum amount must be a positive value.")]
        public decimal MinAmount { get; set; }

        [Required(ErrorMessage = "Maximum amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum amount must be a positive value.")]
        public decimal MaxAmount { get; set; }

        [Required(ErrorMessage = "Minimum policy term is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum policy term must be at least 1 year.")]
        public int MinPolicyTerm { get; set; }

        [Required(ErrorMessage = "Maximum policy term is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Maximum policy term must be at least 1 year.")]
        public int MaxPolicyTerm { get; set; }

        [Required(ErrorMessage = "Minimum age is required.")]
        [Range(0, 100, ErrorMessage = "Minimum age must be between 0 and 100.")]
        public int MinAge { get; set; }

        [Required(ErrorMessage = "Maximum age is required.")]
        [Range(0, 100, ErrorMessage = "Maximum age must be between 0 and 100.")]
        public int MaxAge { get; set; }
        public float ProfitRatio { get; set; }
        public float SettlementRatio { get; set; }

        public float RegistrationCommission { get; set; }

        public float InstallmentCommission { get; set; }
        public bool IsActive { get; set; } = true;
        public InsurancePlanDto? InsurancePlan { get; set; }
    }
}
