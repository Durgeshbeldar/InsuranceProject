using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Employee
    {
        [Key]
        [ForeignKey("User")]
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        public string Department { get; set; } // Enum: Claims, Underwriting, Support

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public User User { get; set; }
    }
}
