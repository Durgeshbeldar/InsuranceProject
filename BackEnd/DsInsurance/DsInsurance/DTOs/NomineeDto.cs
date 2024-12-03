using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class NomineeDto
    {
        public Guid? NomineeId { get; set; }

        [Required(ErrorMessage = "Policy number is required.")]
        public Guid PolicyNo { get; set; }

        [Required(ErrorMessage = "Nominee name is required.")]
        [StringLength(50, ErrorMessage = "Nominee name cannot exceed 50 characters.")]
        public string NomineeName { get; set; }

        [Required(ErrorMessage = "Relationship is required.")]
        [StringLength(50, ErrorMessage = "Relationship cannot exceed 50 characters.")]
        public string Relationship { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int Age { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? Contact { get; set; }
    }
}
