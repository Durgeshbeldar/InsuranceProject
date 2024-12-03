using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class InsurancePlanDto
    {
        public Guid? PlanId { get; set; }

        [Required(ErrorMessage = "Plan name is required.")]
        [StringLength(100, ErrorMessage = "Plan name cannot exceed 100 characters.")]
        public string PlanName { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Scheme ID is required.")]
        public Guid SchemeId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
