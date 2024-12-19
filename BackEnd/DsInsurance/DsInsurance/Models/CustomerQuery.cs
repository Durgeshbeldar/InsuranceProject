using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class CustomerQuery
    {
        [Key]
        public Guid QueryId { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [ForeignKey("PolicyAccount")]
        public Guid? PolicyNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string? Response { get; set; }

        [ForeignKey("Employee")]
        public Guid? ResolvedBy { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public PolicyAccount? PolicyAccount { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
    }
}
