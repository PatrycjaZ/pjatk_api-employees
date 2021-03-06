﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pjatk_api_employees.DAL;
using pjatk_api_employees.DTOs.Employees;

namespace pjatk_api_employees.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IExampleService _service;

        public EmployeesController(IExampleService service) // ctor + tab + tab
        {
            _service = service;
        }

        // localhost:52269/api/employees
        // localhost:52269/api/employees?lastname=Banan
        [HttpGet]
        public IActionResult GetEmployees(string lastname)
        {
            return Ok(_service.GetEmployeesCollection(lastname));
        }

        // localhost:52269/api/employees/1
        [HttpGet("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            var result = _service.GetEmployeeById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound($"Employee with provided id ({id}) not found");
        }

        // localhost:52269/api/employees [+ body]
        [HttpPost]
        public IActionResult AddEmployee(EmployeesRequestDto requestDto)
        {
            if (_service.AddEmployee(requestDto))
                return Ok("New employee created");
            else
                return BadRequest("Something went wrong");
        }

        // localhost:52269/api/employees/40
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_service.DeleteEmployee(id))
                return Ok($"Employee with id ({id}) has been deleted.");
            else 
                return BadRequest($"Employee with provided id ({id}) not found");
        }

        // localhost:52269/api/employees/2 [+ body]
        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, EmployeesRequestDto requestDto)
        {
            if (_service.UpdateEmployee(id, requestDto))
                return Ok($"Employee with id ({id}) has been updated.");
            else
                return BadRequest($"Employee with provided id ({id}) not found");
        }

        // localhost:52269/api/employees/test 
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(_service.Test());
        }
    }
}