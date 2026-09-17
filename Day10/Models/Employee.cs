namespace Day10.Models;

/// <summary>
/// Represents an employee in the organization.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the unique employee ID.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the employee name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee department.
    /// </summary>
    public string Department { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee salary.
    /// </summary>
    public decimal Salary { get; set; }
}