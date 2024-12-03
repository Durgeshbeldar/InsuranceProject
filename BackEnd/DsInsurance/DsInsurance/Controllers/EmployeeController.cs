using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(new
            {
                Message = "Employees retrieved successfully.",
                Data = employees
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return Ok(new
            {
                Message = "Employee retrieved successfully.",
                Data = employee
            });
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {
            var employeeId = _employeeService.AddEmployee(employeeDto);
            return Ok(new
            {
                Message = "Employee added successfully.",
                EmployeeId = employeeId
            });
        }

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            _employeeService.UpdateEmployee(employeeDto);
            return Ok(new
            {
                Message = "Employee updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok(new
            {
                Message = "Employee deleted successfully."
            });
        }
    }
}
