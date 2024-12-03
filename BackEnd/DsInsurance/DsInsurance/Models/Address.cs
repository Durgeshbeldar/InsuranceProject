using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        [StringLength(10)]
        public string HouseNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(100)]
        public string? Town { get; set; }


        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [Required]
        [StringLength(10)]
        public string Pincode { get; set; }

        // Navigation Properties
        public City City { get; set; }
        public State State { get; set; }
    }
}
