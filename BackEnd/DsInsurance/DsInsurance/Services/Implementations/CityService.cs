using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class CityService: ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public CityService(IRepository<City> cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public List<CityDto> GetAllCities()
        {
            var cities = _cityRepository.GetAll().ToList();
            if (!cities.Any())
                throw new NotFoundException("Cities not found.");

            return _mapper.Map<List<CityDto>>(cities);
        }

        public CityDto GetCityById(Guid cityId)
        {
            var city = _cityRepository.GetById(cityId);
            if (city == null)
                throw new NotFoundException("City not found.");

            return _mapper.Map<CityDto>(city);
        }

        public Guid AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _cityRepository.Add(city);

            return city.CityId;
        }

        public void UpdateCity(CityDto cityDto)
        {
            var city = _cityRepository.GetById(cityDto.CityId.Value);
            if (city == null)
                throw new NotFoundException("City not found for update.");

            city = _mapper.Map<City>(cityDto);
            _cityRepository.Update(city);
        }

        public void DeleteCity(Guid cityId)
        {
            var city = _cityRepository.GetById(cityId);
            if (city == null)
                throw new NotFoundException("City not found for deletion.");

            _cityRepository.Delete(city);
        }
    }
}
