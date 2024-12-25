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
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : null)) // Map RoleName from Role entity
            .ReverseMap()
            .ForMember(dest => dest.Role, opt => opt.Ignore());

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

            CreateMap<PolicyAccount, PolicyAccountDto>();
            CreateMap<PolicyAccountDto, PolicyAccount>();

            CreateMap<CustomerQuery, CustomerQueryDto>();
            CreateMap<CustomerQueryDto, CustomerQuery>();

            CreateMap<Claim, ClaimDto>();
            CreateMap<ClaimDto, Claim>();

            CreateMap<PolicyCoverage, PolicyCoverageDto>();
            CreateMap<PolicyCoverageDto, PolicyCoverage>();

            CreateMap<PolicyTransaction, PolicyTransactionDto>();
            CreateMap<PolicyTransactionDto, PolicyTransaction>();

            CreateMap<Installment, InstallmentDto>();
            CreateMap<InstallmentDto, Installment>();

            CreateMap<WithdrawalRequest, WithdrawalRequestDto>();
            CreateMap<WithdrawalRequestDto, WithdrawalRequest>();

            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();

            CreateMap<City, CityDto>()
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Name));
            CreateMap<CityDto, City>();

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();

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
