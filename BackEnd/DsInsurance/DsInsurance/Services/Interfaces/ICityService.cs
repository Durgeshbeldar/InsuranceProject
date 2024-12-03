using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface ICityService
    {
        List<CityDto> GetAllCities();
        CityDto GetCityById(Guid cityId);
        Guid AddCity(CityDto cityDto);
        void UpdateCity(CityDto cityDto);
        void DeleteCity(Guid cityId);
    }
}
