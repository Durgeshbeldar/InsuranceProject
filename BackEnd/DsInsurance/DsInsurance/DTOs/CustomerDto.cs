using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "Customer ID (User ID) is required.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required (ErrorMessage = "Gender is required field")]
        [StringLength(15)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }
        public Guid? AddressId { get; set; }

        public Guid? AgentId { get; set; }

        public bool? KycVerified { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
