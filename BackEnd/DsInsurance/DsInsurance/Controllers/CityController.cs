using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _cityService.GetAllCities();
            return Ok(new
            {
                Message = "Cities retrieved successfully.",
                Data = cities
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(Guid id)
        {
            var city = _cityService.GetCityById(id);
            return Ok(new
            {
                Message = "City retrieved successfully.",
                Data = city
            });
        }

        [HttpPost]
        public IActionResult AddCity(CityDto cityDto)
        {
            var cityId = _cityService.AddCity(cityDto);
            return Ok(new
            {
                Message = $"City Added Successfully with ID: {cityId}"
            });
        }

        [HttpPut]
        public IActionResult UpdateCity(CityDto cityDto)
        {
            _cityService.UpdateCity(cityDto);
            return Ok(new
            {
                Message = "City updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(Guid id)
        {
            _cityService.DeleteCity(id);
            return Ok(new
            {
                Message = "City deleted successfully."
            });
        }
    }
}
