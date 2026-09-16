using AutoMapper;
using Day09.DTOs;
using Day09.Models;
using Day09.UnitOfWork;

namespace Day09.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<List<EmployeeResponseDto>> GetAllAsync()
    {
        var employees = await unitOfWork.Employees.GetAllAsync();

        return mapper.Map<List<EmployeeResponseDto>>(employees);
    }

    public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);

        return mapper.Map<EmployeeResponseDto?>(employee);
    }

    public async Task AddAsync(CreateEmployeeDto employeeDto)
    {
        var employee = mapper.Map<Employee>(employeeDto);

        await unitOfWork.Employees.AddAsync(employee);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        var existingEmployee =
            await unitOfWork.Employees.GetByIdAsync(employee.EmployeeId);

        if (existingEmployee == null)
            return;

        existingEmployee.Name = employee.Name;
        existingEmployee.Email = employee.Email;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.DepartmentId = employee.DepartmentId;
        existingEmployee.ManagerId = employee.ManagerId;

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);

        if (employee == null)
            return;

        unitOfWork.Employees.Delete(employee);
        await unitOfWork.SaveChangesAsync();
    }
}