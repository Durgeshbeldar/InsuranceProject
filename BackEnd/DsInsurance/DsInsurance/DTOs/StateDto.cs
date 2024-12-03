using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class StateDto
    {
        public Guid? StateId { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters.")]
        public string Name { get; set; }
    }
}
