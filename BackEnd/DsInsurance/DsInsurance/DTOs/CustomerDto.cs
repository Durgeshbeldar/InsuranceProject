using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class CustomerDto
    {
        public Guid? CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address ID is required.")]
        public int AddressId { get; set; }

        public bool KycVerified { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? AddressDetails { get; set; }

    }
}
