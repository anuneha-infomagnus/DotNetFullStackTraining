using Day09.DTOs;
using Day09.Models;

namespace Day09.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponseDto>> GetAllAsync();
    Task<EmployeeResponseDto?> GetByIdAsync(int id);

    Task AddAsync(CreateEmployeeDto employeeDto);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}