namespace DsInsurance.DTOs
{
    public class PolicyApprovedDto
    {
        public Guid PolicyNo { get; set; }
        public bool? IsApproved { get; set; }
        public string Status { get; set; }
        public DateTime? IssueDate { get; set; }
        public bool? KycVerified { get; set; }
        public DateTime? MaturityDate { get; set; }
    }
}
