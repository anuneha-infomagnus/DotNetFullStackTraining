using Day08.Data;
using Day08.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day08.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService service;

    public EmployeesController(EmployeeService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await service.GetAllAsync();

        return Ok(employees);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchEmployees(string? name)
    {
        var employees = await service.SearchAsync(name!);

        return Ok(employees);
    }
    [HttpGet("department/{departmentId}")]
    public async Task<IActionResult> GetEmployeesByDepartment(int departmentId)
    {
        var employees = await service.GetByDepartmentAsync(departmentId);

        return Ok(employees);
    }
    [HttpGet("lazy/{id}")]
    public async Task<IActionResult> GetEmployeeLazy(int id)
    {
        var employee = await service.GetByIdLazyAsync(id);

        if (employee == null)
            return NotFound();

        var departmentName = employee.Department.DepartmentName;

        return Ok(employee);
    }
    [HttpGet("explicit/{id}")]
    public async Task<IActionResult> GetEmployeeExplicit(int id)
    {
        var employee = await service.GetByIdExplicitAsync(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }
    [HttpPost("transaction/{id}")]
    public async Task<IActionResult> TransactionDemo(int id, bool fail = false)
    {
        var result = await service.TransactionDemoAsync(id, fail);

        if (!result)
            return NotFound();

        return Ok("Transaction committed successfully.");
    }
}