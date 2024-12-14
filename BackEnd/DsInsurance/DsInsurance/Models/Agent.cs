using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Agent
    {
        [Key]
        [ForeignKey("User")]
        public Guid AgentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }

        public bool? KycVerified { get; set; } = false;

        public decimal? TotalCommission { get; set; } = 0;

        public float? Rating { get; set; } = 0; // Can Show The Ratings of Agent

        public DateTime? ActiveSince { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public User? User { get; set; }
        public Address? Address { get; set; }
        public ICollection<PolicyAccount>? PolicyAccounts { get; set; }

        public ICollection<Customer>? Customers { get; set; }
    }
}
