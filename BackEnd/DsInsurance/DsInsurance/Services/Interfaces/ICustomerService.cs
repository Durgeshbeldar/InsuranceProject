using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(Guid customerId);
        Guid AddCustomer(CustomerDto customerDto);
        void UpdateCustomer(CustomerDto customerDto);
        void DeleteCustomer(Guid customerId);
        public bool ChangeKycStatus(VerifyCustomerDto verifyCustomerDto);
    }
}
