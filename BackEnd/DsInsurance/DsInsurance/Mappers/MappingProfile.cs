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

            CreateMap<Agent, AgentDto>();
            CreateMap<AgentDto, Agent>();

            CreateMap<Admin, AdminDto>();
            CreateMap<AdminDto, Admin>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Nominee, NomineeDto>();
            CreateMap<NomineeDto, Nominee>();

            CreateMap<InsurancePlan, InsurancePlanDto>();
            CreateMap<InsurancePlanDto, InsurancePlan>();

            CreateMap<InsuranceScheme, InsuranceSchemeDto>();
            CreateMap<InsuranceSchemeDto, InsuranceScheme>();

            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<PolicyAccount, PolicyAccountDto>();
            CreateMap<PolicyAccountDto, PolicyAccount>();

            CreateMap<PolicyCoverage, PolicyCoverageDto>();
            CreateMap<PolicyCoverageDto, PolicyCoverage>();

            CreateMap<PolicyRider, PolicyRiderDto>();
            CreateMap<PolicyRiderDto, PolicyRider>();

            CreateMap<PolicyTransaction, PolicyTransactionDto>();
            CreateMap<PolicyTransactionDto, PolicyTransaction>();

        }
    }
}
