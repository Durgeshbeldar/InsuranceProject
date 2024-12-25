using DsInsurance.Models;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Employee ID (User ID) is required.")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required (ErrorMessage ="Dob is required")]
        public DateTime DateOfBirth { get; set; }

        [Required (ErrorMessage ="Gender is an mandatory field")]
        [StringLength(15)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Joining date is required.")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        public User? User { get; set; }
    }
}
