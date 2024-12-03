using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class DocumentDto
    {
        public Guid? DocumentId { get; set; }

        [Required(ErrorMessage = "Document name is required.")]
        [StringLength(100, ErrorMessage = "Document name cannot exceed 100 characters.")]
        public string DocumentName { get; set; }

        [Required(ErrorMessage = "Document content is required.")]
        public byte[] Content { get; set; }

        public bool Verified { get; set; } = false;

        [Required(ErrorMessage = "UploadedBy User ID is required.")]
        public int UploadedBy { get; set; }
    }
}
