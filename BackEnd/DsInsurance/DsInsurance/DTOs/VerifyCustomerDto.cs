namespace DsInsurance.DTOs
{
    public class VerifyCustomerDto
    {
        public Guid CustomerId { get; set; }
        public bool KycVerified {  get; set; }
    }
}
