using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IAddressService
    {
        List<AddressDto> GetAllAddresses();
        AddressDto GetAddressById(Guid addressId);
        Guid AddAddress(AddressDto addressDto);
        void UpdateAddress(AddressDto addressDto);
        void DeleteAddress(Guid addressId);
    }
}
