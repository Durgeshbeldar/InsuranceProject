﻿using DsInsurance.DTOs;
using DsInsurance.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DsInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(new
            {
                Message = "Customers retrieved successfully.",
                Data = customers
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(new
            {
                Message = "Customer retrieved successfully.",
                Data = customer
            });
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDto customerDto)
        {
            var customerId = _customerService.AddCustomer(customerDto);
            return Ok(new
            {
                Message = "Customer added successfully.",
                CustomerId = customerId
            });
        }

        [HttpPut]
        public IActionResult UpdateCustomer(CustomerDto customerDto)
        {
            _customerService.UpdateCustomer(customerDto);
            return Ok(new
            {
                Message = "Customer updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            _customerService.DeleteCustomer(id);
            return Ok(new
            {
                Message = "Customer deleted successfully."
            });
        }
    }
}