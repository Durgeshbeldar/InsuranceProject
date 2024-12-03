using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; } //  We Have Used Enum: Admin, Employee, Agent, Customer

        // Navigation Properties
        public ICollection<User> Users { get; set; }
    }
}
