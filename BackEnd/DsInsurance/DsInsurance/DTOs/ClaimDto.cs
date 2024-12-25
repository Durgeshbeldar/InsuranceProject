using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class ClaimDto
    {
        public Guid? ClaimId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid CustomerId { get; set; }


        [Required(ErrorMessage = "Claim amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Claim amount must be positive.")]
        public decimal ClaimAmount { get; set; }

        [Required(ErrorMessage = "Bank account number is required.")]
        [StringLength(20, ErrorMessage = "Bank account number cannot exceed 20 characters.")]
        public string BankAccountNo { get; set; }

        [Required(ErrorMessage = "Bank account holder name is required.")]
        [StringLength(100, ErrorMessage = "Bank account holder name cannot exceed 100 characters.")]
        public string BankAccountHolderName { get; set; }

        [Required(ErrorMessage = "IFSC code is required.")]
        [StringLength(11, ErrorMessage = "IFSC code cannot exceed 11 characters.")]
        public string IFSCCode { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters.")]
        public string BankName { get; set; }

        public string? Status { get; set; } = "Submitted";

        public string? Message { get; set; }

        public DateTime? ClaimDate { get; set; } = DateTime.UtcNow;

        public DateTime? ApprovalDate { get; set; }
    }
}
