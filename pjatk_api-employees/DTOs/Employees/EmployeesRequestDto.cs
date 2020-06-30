namespace pjatk_api_employees.DTOs.Employees
{
    public class EmployeesRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Info { get; set; }
    }
}
