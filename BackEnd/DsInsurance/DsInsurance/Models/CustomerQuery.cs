using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class CustomerQuery
    {
        [Key]
        public Guid QueryId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Response { get; set; }

        [ForeignKey("Employee")]
        public int? ResolvedBy { get; set; } // Nullable if unresolved

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? ResolvedAt { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
