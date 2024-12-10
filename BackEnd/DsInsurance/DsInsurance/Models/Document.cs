using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Document
    {
        [Key]
        public Guid DocumentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public bool Verified { get; set; } = false;

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        // Navigation Properties
        public User? User { get; set; }
    }
}
