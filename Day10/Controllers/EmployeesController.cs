
using Asp.Versioning;
using Day10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day10.Controllers;

/// <summary>
/// Provides APIs for managing employees.
/// </summary>
[ApiController]
[ApiVersion(1.0)]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeesController : ControllerBase
{
    private static readonly List<Employee> Employees = new()
    {
        new Employee
        {
            EmployeeId = 1,
            Name = "Anu",
            Email = "anu@example.com",
            Department = "IT",
            Salary = 50000
        },
        new Employee
        {
            EmployeeId = 2,
            Name = "Rahul",
            Email = "rahul@example.com",
            Department = "HR",
            Salary = 45000
        }
    };

    /// <summary>
    /// Retrieves all employees using API version 1.
    /// </summary>
    /// <returns>A list of all employees.</returns>
    [HttpGet]
    [MapToApiVersion(1.0)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllEmployees()
    {
        return Ok(Employees);
    }

    /// <summary>
    /// Retrieves all employees using API version 2.
    /// </summary>
    /// <returns>Employee data with version information.</returns>
    [HttpGet]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllEmployeesV2()
    {
        return Ok(new
        {
            Version = "2.0",
            Message = "Employee data from API Version 2",
            Employees
        });
    }

    /// <summary>
    /// Retrieves an employee using the employee ID.
    /// </summary>
    /// <param name="id">The unique ID of the employee.</param>
    /// <returns>The employee details if found.</returns>
    /// <response code="200">Employee found successfully.</response>
    /// <response code="404">Employee was not found.</response>
    [HttpGet("{id}")]
    [MapToApiVersion(1.0)]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="employee">The employee information.</param>
    /// <returns>The newly created employee.</returns>
    /// <response code="200">Employee created successfully.</response>
    [HttpPost]
    [MapToApiVersion(1.0)]
    [MapToApiVersion(2.0)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CreateEmployee(Employee employee)
    {
        employee.EmployeeId = Employees.Max(e => e.EmployeeId) + 1;

        Employees.Add(employee);

        return Ok(employee);
    }
}