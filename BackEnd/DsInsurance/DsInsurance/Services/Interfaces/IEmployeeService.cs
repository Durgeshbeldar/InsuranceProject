using DsInsurance.DTOs;

namespace DsInsurance.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(Guid employeeId);
        Guid AddEmployee(EmployeeDto employeeDto);
        void UpdateEmployee(EmployeeDto employeeDto);
        void DeleteEmployee(Guid employeeId);
    }
}
