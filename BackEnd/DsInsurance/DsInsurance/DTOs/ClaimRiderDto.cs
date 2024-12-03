namespace DsInsurance.DTOs
{
    public class ClaimRiderDto
    {
        public Guid? ClaimId { get; set; }
        public int RiderId { get; set; }
        public bool IsApplicable { get; set; }
    }
}
