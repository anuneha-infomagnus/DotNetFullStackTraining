using System.ComponentModel.DataAnnotations;

namespace Day07.Models
{
    public class EmployeeProfile
    {
        public int EmployeeProfileId { get; set; }

        public int EmployeeId { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public Employee? Employee { get; set; }
    }
}