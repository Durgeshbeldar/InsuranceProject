using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class PolicyCoverage
    {
        [Key]
        public Guid CoverageId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [Required]
        [StringLength(50)]
        public string CoverageType { get; set; }

        [Required]
        public decimal CoverageLimit { get; set; }

        [Required]
        public decimal DeductibleAmount { get; set; }

        [Required]
        public decimal PremiumImpact { get; set; }

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
    }
}
