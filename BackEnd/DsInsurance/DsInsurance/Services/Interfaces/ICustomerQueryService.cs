using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface ICustomerQueryService
    {
        List<CustomerQueryDto> GetAllQueries();
        CustomerQueryDto GetQueryById(Guid queryId);
        Guid AddCustomerQuery(CustomerQueryDto queryDto);
        void UpdateCustomerQuery(CustomerQueryDto queryDto);
        void DeleteCustomerQuery(Guid queryId);
        public List<CustomerQueryDto> GetAllQueriesCustomerId(Guid customerId);
    }
}
