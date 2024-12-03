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
        public byte[] Content { get; set; } // Blob for document storage

        public bool Verified { get; set; } = false;

        [ForeignKey("User")]
        public int UploadedBy { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
