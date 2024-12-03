using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class PolicyRiderDto
    {
        public Guid? RiderId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Rider name is required.")]
        [StringLength(100, ErrorMessage = "Rider name cannot exceed 100 characters.")]
        public string RiderName { get; set; }

        public string? RiderDescription { get; set; }

        [Required(ErrorMessage = "Additional premium is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Additional premium must be a positive value.")]
        public decimal AdditionalPremium { get; set; }

        [Required(ErrorMessage = "Commission is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Commission must be a positive value.")]
        public decimal Commission { get; set; }
    }
}
