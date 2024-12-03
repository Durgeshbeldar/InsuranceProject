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

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public decimal TotalCommission { get; set; }

        public float Rating { get; set; } // Can Show The Ratings of Agent

        public DateTime ActiveSince { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Address Address { get; set; }
        public ICollection<PolicyAccount> PolicyAccounts { get; set; }
    }
}
