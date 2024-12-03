using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DsInsurance.Models
{
    public class ClaimRider
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Claim")]
        public Guid ClaimId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("PolicyRider")]
        public int RiderId { get; set; }

        public bool IsApplicable { get; set; }

        // Navigation Properties
        public Claim Claim { get; set; }
        public PolicyRider PolicyRider { get; set; }
    }
}
