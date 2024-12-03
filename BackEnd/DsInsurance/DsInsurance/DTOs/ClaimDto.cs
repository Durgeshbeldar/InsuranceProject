using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class ClaimDto
    {
        public Guid? ClaimId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public int PolicyNo { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        [Required(ErrorMessage = "Claim reason is required.")]
        [StringLength(200, ErrorMessage = "Claim reason cannot exceed 200 characters.")]
        public string ClaimReason { get; set; }

        [Required(ErrorMessage = "Incident date is required.")]
        public DateTime IncidentDate { get; set; }

        public string? IncidentDescription { get; set; }

        [Required(ErrorMessage = "Supporting document ID is required.")]
        public int SupportingDocumentId { get; set; }

        [Required(ErrorMessage = "Claim amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Claim amount must be positive.")]
        public decimal ClaimAmount { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public decimal? SettlementAmount { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public ICollection<int>? ApplicableRiderIds { get; set; }
    }
}
