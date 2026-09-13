namespace Day08.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public int? ManagerId { get; set; }
        public virtual Department Department { get; set; } = null!;
    }
}
