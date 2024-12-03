using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class InsurancePlan
    {
        [Key]
        public Guid PlanId { get; set; }

        [Required]
        [StringLength(100)]
        public string PlanName { get; set; }

        public string Description { get; set; }

        [ForeignKey("InsuranceScheme")]
        public int SchemeId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public InsuranceScheme InsuranceScheme { get; set; }
    }
}
