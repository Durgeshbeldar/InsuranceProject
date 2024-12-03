using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class PolicyRider
    {
        [Key]
        public Guid RiderId { get; set; }

        [ForeignKey("PolicyAccount")]
        public int PolicyNo { get; set; }

        [Required]
        [StringLength(100)]
        public string RiderName { get; set; }

        public string RiderDescription { get; set; }

        [Required]
        public decimal AdditionalPremium { get; set; }

        [Required]
        public decimal Commission { get; set; } // Commission for the agent on this rider

        // Navigation Properties
        public PolicyAccount PolicyAccount { get; set; }
    }
}
