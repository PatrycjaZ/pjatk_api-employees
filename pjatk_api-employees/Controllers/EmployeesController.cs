using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pjatk_api_employees.Controllers
{
    // localhost:52269/api/employees
    [Route("api/employees")] // adres pod jakim dostajemy się do naszego kontrolera
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // localhost:52269/api/employees/test 
        // metoda do sprawdzenia, czy api działa 
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("It works!");
        }

        // localhost:52269/api/employees 
        // zwrócenie listy pracowników
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok("Under construction");
        }
    }
}