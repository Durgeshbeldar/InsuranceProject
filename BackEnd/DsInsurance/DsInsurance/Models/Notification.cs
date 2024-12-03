using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; } // Enum: Email, SMS, Push

        [Required]
        public DateTime CreatedAt { get; set; }

        public bool Read { get; set; } = false;

        // Navigation Properties
        public User User { get; set; }
    }
}
