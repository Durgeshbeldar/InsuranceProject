using DsInsurance.Models;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class CityDto
    {
        public Guid? CityId { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State ID is required.")]
        public Guid StateId { get; set; }
        public string? StateName { get; set; }
    }
}
