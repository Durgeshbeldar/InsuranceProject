using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Nominee
    {
        [Key]
        public Guid NomineeId { get; set; }

        [ForeignKey("PolicyAccount")]
        public Guid PolicyNo { get; set; }

        [Required]
        [StringLength(50)]
        public string NomineeName { get; set; }

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; }

        [Required]
        public int Age { get; set; }

        public bool IsActive { get; set; } = true;

        [Phone]
        public string Contact { get; set; }
    }
}
