using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class TaxSetting
    {
        [Key]
        public Guid TaxId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [Required]
        public float TaxPercentage { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
    }
}
