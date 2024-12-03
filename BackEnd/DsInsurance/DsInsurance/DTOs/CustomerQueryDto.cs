using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class CustomerQueryDto
    {
        public Guid? QueryId { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Response { get; set; }

        public int? ResolvedBy { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }
    }
}
