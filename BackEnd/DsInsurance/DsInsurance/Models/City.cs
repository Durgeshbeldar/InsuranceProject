using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("State")]
        public Guid StateId { get; set; }

        // Navigation Properties
        public State? State { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}
