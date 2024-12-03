using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            var addresses = _addressService.GetAllAddresses();
            return Ok(new
            {
                Message = "Addresses retrieved successfully.",
                Data = addresses
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(Guid id)
        {
            var address = _addressService.GetAddressById(id);
            return Ok(new
            {
                Message = "Address retrieved successfully.",
                Data = address
            });
        }

        [HttpPost]
        public IActionResult AddAddress(AddressDto addressDto)
        {
            var addressId = _addressService.AddAddress(addressDto);
            return Ok(new
            {
                Message = $"Address Added Successfully with ID: {addressId}"
            });
        }

        [HttpPut]
        public IActionResult UpdateAddress(AddressDto addressDto)
        {
            _addressService.UpdateAddress(addressDto);
            return Ok(new
            {
                Message = "Address updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(Guid id)
        {
            _addressService.DeleteAddress(id);
            return Ok(new
            {
                Message = "Address deleted successfully."
            });
        }
    }
}
