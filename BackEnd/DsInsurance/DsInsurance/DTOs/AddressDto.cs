using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class AddressDto
    {
        // Output: Used for identification in response
        public Guid? AddressId { get; set; } // Nullable, as ID is not required during creation

        // Input & Output: Common fields for both operations
        [Required(ErrorMessage = "House number is required.")]
        [StringLength(10, ErrorMessage = "House number cannot exceed 10 characters.")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "Street name is required.")]
        [StringLength(100, ErrorMessage = "Street name cannot exceed 100 characters.")]
        public string Street { get; set; }

        [StringLength(100, ErrorMessage = "Town name cannot exceed 100 characters.")]
        public string? Town { get; set; }

        // Input: Foreign keys for creation/updation
        [Required(ErrorMessage = "City ID is required.")]
        public Guid? CityId { get; set; }

        [Required(ErrorMessage = "State ID is required.")]
        public Guid? StateId { get; set; }

        // Output: Human-readable names for response
        public string? CityName { get; set; } // Nullable because it won't be provided during creation
        public string? StateName { get; set; } // Nullable because it won't be provided during creation

        // Input & Output: Common field for both
        [Required(ErrorMessage = "Pincode is required.")]
        [StringLength(10, ErrorMessage = "Pincode cannot exceed 10 characters.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be a valid 6-digit number.")]
        public string Pincode { get; set; }
    }
}
