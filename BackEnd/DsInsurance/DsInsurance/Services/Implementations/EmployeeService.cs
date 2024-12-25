using AutoMapper;
using DsInsurance.DTOs;
using DsInsurance.Exceptions;
using DsInsurance.Models;
using DsInsurance.Repositories.Interfaces;
using DsInsurance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DsInsurance.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().Include(emp=> emp.User).ToList();
            if (!employees.Any())
                throw new NotFoundException("Employees");

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
                throw new NotFoundException("Employee");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public Guid AddEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Add(employee);
            return employee.EmployeeId;
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {
            var existingEmployee = _employeeRepository.GetById(employeeDto.EmployeeId);
            if (existingEmployee == null)
                throw new NotFoundException("Employee");

            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
                throw new NotFoundException("Employee");

            _employeeRepository.Delete(employee);
        }
    }
}
