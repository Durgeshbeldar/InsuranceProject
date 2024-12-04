using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class InsuranceScheme
    {
        [Key]
        public Guid SchemeId { get; set; }

        [Required]
        [StringLength(100)]
        public string SchemeName { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal MinAmount { get; set; }

        [Required]
        public decimal MaxAmount { get; set; }

        [Required]
        public int MinPolicyTerm { get; set; }

        [Required]
        public int MaxPolicyTerm { get; set; }

        [Required]
        public int MinAge { get; set; }

        [Required]
        public int MaxAge { get; set; }

        public float ProfitRatio { get; set; }
        public float SettlementRatio { get; set; }
        public float RegistrationCommission { get; set; }

        public float InstallmentCommission { get; set; }

        public ICollection<InsurancePlan>? InsurancePlans { get; set; }
    }
}
