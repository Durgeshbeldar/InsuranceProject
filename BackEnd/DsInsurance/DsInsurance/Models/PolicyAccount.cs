using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace DsInsurance.Models
{
    public class PolicyAccount
    {
        [Key]
        public Guid PolicyNo { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [ForeignKey("Agent")]
        public Guid? AgentId { get; set; }

        [ForeignKey("InsuranceScheme")]
        public Guid SchemeId { get; set; }


        [Required]
        public decimal SumAssured { get; set; } 

        [Required]
        public string PremiumType { get; set; } // Enum: Monthly, Quarterly, Yearly

        [Required]
        public int PolicyTerm { get; set; } // Term in Month 


        [Required]
        public double PremiumAmount { get; set; }

        [Required]
        public decimal TotalPaidAmount { get; set; } = 0;

        public decimal? InstallmentAmount { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        public DateTime AppliedDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? CancellationDate { get; set; }

        [Required]
        public DateTime MaturityDate { get; set; }

        [Required]
        public string Status { get; set; } // Enum: Active, Lapsed, Surrendered

        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public Customer? Customer { get; set; }
        public Agent? Agent { get; set; }
        public InsuranceScheme? InsuranceScheme { get; set; }
        public ICollection<PolicyCoverage>? PolicyCoverages { get; set; }
        public ICollection<Installment>? Installments { get; set; }
        public ICollection<PolicyTransaction>? PolicyTransactions { get; set; }
        public ICollection<Nominee>? Nominees { get; set; }


    }
}
