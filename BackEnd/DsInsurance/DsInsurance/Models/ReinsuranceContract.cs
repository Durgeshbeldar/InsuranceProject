using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class ReinsuranceContract
    {
        [Key]
        public Guid ReinsuranceId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [Required]
        [StringLength(100)]
        public string ReinsurerName { get; set; }

        [Required]
        public float CoveragePercentage { get; set; }

        [Required]
        public string ContractTerms { get; set; } // Details of the reinsurance agreement

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
    }
}
