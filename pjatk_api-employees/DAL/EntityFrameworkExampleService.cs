using pjatk_api_employees.DTOs.Employees;
using pjatk_api_employees.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using pjatk_api_employees.DTOs.Participate;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace pjatk_api_employees.DAL
{
    public class EntityFrameworkExampleService : IExampleService
    {
        private readonly API_PROJEKTContext context;
        public EntityFrameworkExampleService(API_PROJEKTContext _context)
        {
            context = _context;
        }

        public bool AddEmployee(EmployeesRequestDto newEmployee)
        {
            try
            {
                var employeeToAdd = new Pracownik
                {
                    Imie = newEmployee.FirstName,
                    Nazwisko = newEmployee.LastName,
                    RokUr = newEmployee.BirthYear,
                    Miasto = newEmployee.City,
                    Stanowisko = newEmployee.Job,
                    Email = newEmployee.Email,
                    NrTel = newEmployee.PhoneNo,
                    TablicaInfo = newEmployee.Info
                };

                context.Pracownik.Add(employeeToAdd);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var employeeToRemove = context.Pracownik.SingleOrDefault(x => x.Idpracownik == id);
                if (employeeToRemove == null)
                    return false;
                else
                {
                    context.Pracownik.Remove(employeeToRemove);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmployee(int id, EmployeesRequestDto updateEmployee)
        {
            var employeeToEdit = context.Pracownik.SingleOrDefault(x => x.Idpracownik == id);
            if (employeeToEdit == null)
                return false;
            else
            {
                employeeToEdit.Imie = updateEmployee.FirstName;
                employeeToEdit.Nazwisko = updateEmployee.LastName;
                employeeToEdit.RokUr = updateEmployee.BirthYear;
                employeeToEdit.Miasto = updateEmployee.City;
                employeeToEdit.Stanowisko = updateEmployee.Job;
                employeeToEdit.Email = updateEmployee.Email;
                employeeToEdit.NrTel = updateEmployee.PhoneNo;
                employeeToEdit.TablicaInfo = updateEmployee.Info;
                context.SaveChanges();
                return true;
            }
        }

        public EmployeesResponseDto GetEmployeeById(int idEmployee)
        {
            return context.Pracownik
                .Where(x => x.Idpracownik == idEmployee)
                .Include(x => x.UdzialWSpotkaniu)
                .Select(x => new EmployeesResponseDto
                {
                    IdEmployee = x.Idpracownik,
                    FirstName = x.Imie,
                    LastName = x.Nazwisko,
                    BirthYear = x.RokUr,
                    City = x.Miasto,
                    Job = x.Stanowisko,
                    Email = x.Email,
                    PhoneNo = x.NrTel,
                    Info = x.TablicaInfo,
                    ParticipateInMeeting = x.UdzialWSpotkaniu.Select(x => new ParticipateResponseDto
                    {
                        IdMeeting = x.SpotkanieIdspotkanie,
                        MeetingSpot = x.MiejsceSpotkania
                    }).ToList()
                })
                .SingleOrDefault();
        }

        public ICollection<EmployeesResponseDto> GetEmployeesCollection(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                return context.Pracownik
                    .Include(x => x.UdzialWSpotkaniu)
                    .Select(x => new EmployeesResponseDto
                    {
                        IdEmployee = x.Idpracownik,
                        FirstName = x.Imie,
                        LastName = x.Nazwisko,
                        BirthYear = x.RokUr,
                        City = x.Miasto,
                        Job = x.Stanowisko,
                        Email = x.Email,
                        PhoneNo = x.NrTel,
                        Info = x.TablicaInfo,
                        ParticipateInMeeting = x.UdzialWSpotkaniu.Select(x => new ParticipateResponseDto
                        {
                            IdMeeting = x.SpotkanieIdspotkanie,
                            MeetingSpot = x.MiejsceSpotkania
                        }).ToList()
                    })
                    .ToList();
            else
                return context.Pracownik
                    .Where(x => x.Nazwisko == lastName)
                    .Include(x => x.UdzialWSpotkaniu)
                    .Select(x => new EmployeesResponseDto
                    {
                        IdEmployee = x.Idpracownik,
                        FirstName = x.Imie,
                        LastName = x.Nazwisko,
                        BirthYear = x.RokUr,
                        City = x.Miasto,
                        Job = x.Stanowisko,
                        Email = x.Email,
                        PhoneNo = x.NrTel,
                        Info = x.TablicaInfo,
                        ParticipateInMeeting = x.UdzialWSpotkaniu.Select(x => new ParticipateResponseDto
                        {
                            IdMeeting = x.SpotkanieIdspotkanie,
                            MeetingSpot = x.MiejsceSpotkania
                        }).ToList()
                    })
                    .ToList();
        }

        public string Test()
        {
            return "It works!";
        }
    }
}
