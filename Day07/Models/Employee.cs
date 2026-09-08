using System.ComponentModel.DataAnnotations;

namespace Day07.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public int? ManagerId { get; set; }

        public Department? Department { get; set; }

        public Employee? Manager { get; set; }

        public ICollection<Employee> Reports { get; set; } = new List<Employee>();
        public EmployeeProfile? Profile { get; set; }
    }
}