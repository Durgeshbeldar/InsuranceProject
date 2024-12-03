using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class TaxSettingDto
    {
        public Guid? TaxId { get; set; }

        [Required(ErrorMessage = "Policy ID is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Tax percentage is required.")]
        [Range(0, 100, ErrorMessage = "Tax percentage must be between 0 and 100.")]
        public float TaxPercentage { get; set; }

        [Required(ErrorMessage = "Updated date is required.")]
        public DateTime UpdatedAt { get; set; }
    }
}
