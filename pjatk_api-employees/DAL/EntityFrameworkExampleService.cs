using pjatk_api_employees.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pjatk_api_employees.DAL
{
    public class EntityFrameworkExampleService : IExampleService
    {
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
