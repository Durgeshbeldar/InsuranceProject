using System.ComponentModel.DataAnnotations;

namespace DsInsurance.DTOs
{
    public class NotificationDto
    {
        public Guid? NotificationId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Notification type is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime CreatedAt { get; set; }

        public bool Read { get; set; } = false;
    }
}
