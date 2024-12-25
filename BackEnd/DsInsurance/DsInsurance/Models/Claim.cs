using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DsInsurance.Models
{
    public class Claim
    {
        [Key]
        public Guid ClaimId { get; set; }

        [ForeignKey("PolicyAccount")]
        public Guid PolicyNo { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [Required]
        public decimal ClaimAmount { get; set; }

        [Required]
        public string BankAccountNo { get; set; }

        [Required]
        public string BankAccountHolderName { get; set; }

        [Required]
        public string IFSCCode { get; set; }

        [Required]
        public string BankName { get; set; }

        public string? Status { get; set; } = "Submitted";
  
        public string? Message { get; set; }

        public DateTime? ClaimDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovalDate { get; set; }

        // Navigation Properties
      
        public PolicyAccount? PolicyAccount { get; set; }
        public Customer? Customer { get; set; }
    }
}
