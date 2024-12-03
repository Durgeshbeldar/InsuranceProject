using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IRepository<Address> addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public List<AddressDto> GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll().ToList();
            if (!addresses.Any())
                throw new NotFoundException("Addresses not found.");

            return _mapper.Map<List<AddressDto>>(addresses);
        }

        public AddressDto GetAddressById(Guid addressId)
        {
            var address = _addressRepository.GetById(addressId);
            if (address == null)
                throw new NotFoundException("Address not found.");

            return _mapper.Map<AddressDto>(address);
        }

        public Guid AddAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _addressRepository.Add(address);

            return address.AddressId;
        }

        public void UpdateAddress(AddressDto addressDto)
        {
            var address = _addressRepository.GetById(addressDto.AddressId.Value);
            if (address == null)
                throw new NotFoundException("Address not found for update.");

            address = _mapper.Map<Address>(addressDto);
            _addressRepository.Update(address);
        }

        public void DeleteAddress(Guid addressId)
        {
            var address = _addressRepository.GetById(addressId);
            if (address == null)
                throw new NotFoundException("Address not found for deletion.");

            _addressRepository.Delete(address);
        }
    }
}
