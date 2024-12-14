using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyAccountDto
    {
        // Primary Key
        public Guid? PolicyNo { get; set; } // Nullable because it is not required during creation


        // Foreign Keys
        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid? CustomerId { get; set; }

        public Guid? AgentId { get; set; }

        [Required(ErrorMessage = "Insurance Scheme ID is required.")]
        public Guid? SchemeId { get; set; }

        // Policy Details
        [Required(ErrorMessage = "Sum Assured is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Sum Assured must be a positive value.")]
        public decimal? SumAssured { get; set; }

        [Required(ErrorMessage = "Premium Type is required.")]
        [StringLength(20, ErrorMessage = "Premium Type cannot exceed 20 characters.")]
        public string PremiumType { get; set; } // Enum: Monthly, Quarterly, Yearly

        [Required(ErrorMessage = "Policy Term is required.")]
        [Range(1, 1200, ErrorMessage = "Policy Term must be at least 1 month.")]
        public int? PolicyTerm { get; set; } // Term in months

        [Required(ErrorMessage = "Premium Amount is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Premium Amount must be a positive value.")]
        public double? PremiumAmount { get; set; }

    
        [Range(0, double.MaxValue, ErrorMessage = "Total Paid Amount cannot be negative.")]
        public decimal TotalPaidAmount { get; set; } = 0; // Default to 0

        [Range(0, double.MaxValue, ErrorMessage = "Installment Amount cannot be negative.")]
        public decimal? InstallmentAmount { get; set; }

     
        public bool IsApproved { get; set; } = false; // Default to false

        [Required (ErrorMessage ="Issue Date is required.")]
        public DateTime AppliedDate { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? CancellationDate { get; set; }

        [Required(ErrorMessage = "Maturity Date is required.")]
        public DateTime? MaturityDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        public string Status { get; set; } // Enum: Active, Lapsed, Surrendered

        public bool IsActive { get; set; } = true;

        // Navigation Properties (For Output)
        public CustomerDto? Customer { get; set; }
        public AgentDto? Agent { get; set; }
        public InsuranceSchemeDto? InsuranceScheme { get; set; }

        public ICollection<PolicyCoverageDto>? PolicyCoverages { get; set; }
        public ICollection<InstallmentDto>? Installments { get; set; }
        public ICollection<PolicyTransactionDto>? PolicyTransactions { get; set; }
        public ICollection<NomineeDto>? Nominees { get; set; }
    }
}
