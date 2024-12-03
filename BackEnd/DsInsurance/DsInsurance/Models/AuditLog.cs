using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class AuditLog
    {
        [Key]
        public Guid AuditId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionType { get; set; }

        public string ActionDetails { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
