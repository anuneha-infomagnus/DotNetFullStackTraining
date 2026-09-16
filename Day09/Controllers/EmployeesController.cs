using Day09.DTOs;
using Day09.Models;
using Day09.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day09.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService service;

    public EmployeesController(IEmployeeService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await service.GetAllAsync();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await service.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateEmployeeDto employeeDto)
    {
        await service.AddAsync(employeeDto);

        return Ok(employeeDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Employee employee)
    {
        if (id != employee.EmployeeId)
            return BadRequest("ID mismatch.");

        var existingEmployee = await unitOfWorkCheck(id);

        if (!existingEmployee)
            return NotFound();

        await service.UpdateAsync(employee);

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await service.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        await service.DeleteAsync(id);

        return Ok("Employee deleted successfully.");
    }

    private async Task<bool> unitOfWorkCheck(int id)
    {
        var employee = await service.GetByIdAsync(id);

        return employee != null;
    }
}