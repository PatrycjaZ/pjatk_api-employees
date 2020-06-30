using pjatk_api_employees.DTOs.Employees;
using pjatk_api_employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pjatk_api_employees.DAL
{
    public class EntityFrameworkExampleService : IExampleService
    {
        private readonly API_PROJEKTContext context;
        public EntityFrameworkExampleService(API_PROJEKTContext _context)
        {
            context = _context;
        }
        public ICollection<EmployeesResponseDto> GetEmployeesCollection(string lastName)
        {
            throw new NotImplementedException();
        }

        public string Test()
        {
            return "It works!";
        }
    }
}
