using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class State
    {
        [Key]
        public Guid StateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<City> Cities { get; set; }
    }
}
