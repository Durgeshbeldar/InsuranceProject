using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AdminDto
    {
        public Guid? AdminId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(15, ErrorMessage = "Gender cannot exceed 15 characters.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address ID is required.")]
        public Guid? AddressId { get; set; }

        public string? AddressDetails { get; set; } // Optional for response

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
