using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pjatk_api_employees.DAL;

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

        // localhost:52269/api/employees/test 
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("It works!");
        }

        // localhost:52269/api/employees 
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok("Under construction");
        }
    }
}