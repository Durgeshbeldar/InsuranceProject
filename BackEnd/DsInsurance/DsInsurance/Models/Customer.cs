using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DsInsurance.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("User")]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }

        [ForeignKey("Agent")]
        public Guid? AgentId { get; set; }

        public bool KycVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public User? User { get; set; }
        public Agent? Agent { get; set; }
        public Address? Address { get; set; }
        public ICollection<Document>? Documents { get; set; }
    }
}

