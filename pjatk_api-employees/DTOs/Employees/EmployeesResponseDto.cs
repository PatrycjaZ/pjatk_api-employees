using pjatk_api_employees.DTOs.Participate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pjatk_api_employees.DTOs.Employees
{
    public class EmployeesResponseDto
    {
        public EmployeesResponseDto()
        {
            ParticipateInMeeting = new List<ParticipateResponseDto>();
        }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Info { get; set; }

        public ICollection<ParticipateResponseDto> ParticipateInMeeting { get; set; }
    }
}
