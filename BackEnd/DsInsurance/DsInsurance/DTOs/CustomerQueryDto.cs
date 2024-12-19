using DsInsurance.Models;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class CustomerQueryDto
    {
        public Guid? QueryId { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid CustomerId { get; set; }

        public Guid? PolicyNo { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Response { get; set; }

        public Guid? ResolvedBy { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }

        public bool IsActive { get; set; } = true;

        public PolicyAccount? PolicyAccount { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
    }
}
