using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class RoleDto
    {
        public Guid? RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(20, ErrorMessage = "Role name cannot exceed 20 characters.")]
        public string RoleName { get; set; }
    }
}
