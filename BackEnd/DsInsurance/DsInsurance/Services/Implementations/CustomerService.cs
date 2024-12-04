using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;

namespace DsInsurance.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public List<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll().ToList();
            if (!customers.Any())
                throw new NotFoundException("Customers");

            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
                throw new NotFoundException("Customer");

            return _mapper.Map<CustomerDto>(customer);
        }

        public Guid AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Add(customer);
            return customer.CustomerId;
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var existingCustomer = _customerRepository.GetById(customerDto.CustomerId);
            if (existingCustomer == null)
                throw new NotFoundException("Customer");

            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            var employee = _customerRepository.GetById(id);
            if (employee == null)
                throw new NotFoundException("Customer");

            _customerRepository.Delete(employee);
        }
    }
}
