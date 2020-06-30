using pjatk_api_employees.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pjatk_api_employees.DAL
{
    public interface IExampleService
    {
        string Test();
        ICollection<EmployeesResponseDto> GetEmployeesCollection(string lastName);
        EmployeesResponseDto GetEmployeeById(int idEmployee);
        bool AddEmployee(EmployeesRequestDto newEmployee);
        bool UpdateEmployee(int id, EmployeesRequestDto updateEmployee);
    }
}
