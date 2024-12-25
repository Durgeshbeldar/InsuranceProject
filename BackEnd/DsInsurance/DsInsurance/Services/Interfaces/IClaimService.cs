using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IClaimService
    {
        List<ClaimDto> GetAllClaims();
        ClaimDto GetClaimById(Guid claimId);
        Guid AddClaim(ClaimDto claimDto);
        void UpdateClaim(ClaimDto claimDto);
        void DeleteClaim(Guid claimId);
        public List<ClaimDto> GetClaimsByCustomerId(Guid customerId);
    }
}
