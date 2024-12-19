using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerQueryController : ControllerBase
    {
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerQueryController(ICustomerQueryService customerQueryService)
        {
            _customerQueryService = customerQueryService;
        }

        [HttpGet]
        public IActionResult GetAllQueries()
        {
            var queries = _customerQueryService.GetAllQueries();
            return Ok(new
            {
                Message = "Customer queries retrieved successfully.",
                Data = queries
            });
        }

        [HttpGet("Customer/{customerId}")]

        public IActionResult GetAllQueriesByCustomerId(Guid customerId)
        {
            var queries = _customerQueryService.GetAllQueriesCustomerId(customerId);
            return Ok(new
            {
                Message = "Customer queries retrieved successfully.",
                Data = queries
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetQueryById(Guid id)
        {
            var query = _customerQueryService.GetQueryById(id);
            return Ok(new
            {
                Message = "Customer query retrieved successfully.",
                Data = query
            });
        }

        [HttpPost]
        public IActionResult AddCustomerQuery(CustomerQueryDto queryDto)
        {
            var queryId = _customerQueryService.AddCustomerQuery(queryDto);
            return Ok(new
            {
                Message = "Customer query added successfully.",
                QueryId = queryId
            });
        }

        [HttpPut]
        public IActionResult UpdateCustomerQuery(CustomerQueryDto queryDto)
        {
            _customerQueryService.UpdateCustomerQuery(queryDto);
            return Ok(new
            {
                Message = "Customer query updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerQuery(Guid id)
        {
            _customerQueryService.DeleteCustomerQuery(id);
            return Ok(new
            {
                Message = "Customer query deleted successfully."
            });
        }
    }
}
