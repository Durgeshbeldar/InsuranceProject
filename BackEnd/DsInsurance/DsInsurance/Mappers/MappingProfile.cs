using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Models;

namespace DsInsurance.Mappers
{
    public class MappingProfile : Profile
    {
       
       public MappingProfile()
       {
            // Get Request Mapping
            CreateMap<User, UserDto>();

            // Post Request Mapping
            CreateMap<UserDto, User>();
       }
    }
}
