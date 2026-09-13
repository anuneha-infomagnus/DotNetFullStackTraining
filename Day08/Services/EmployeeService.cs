using Day08.Models;
using Day08.Repositories;

namespace Day08.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        this.repository = repository;
    }
    public async Task<List<Employee>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<List<Employee>> SearchAsync(string name)
    {
        return await repository.SearchAsync(name);
    }
    public async Task<List<Employee>> GetByDepartmentAsync(int departmentId)
    {
        return await repository.GetByDepartmentAsync(departmentId);
    }
    public async Task<Employee?> GetByIdLazyAsync(int id)
    {
        return await repository.GetByIdLazyAsync(id);
    }
    public async Task<Employee?> GetByIdExplicitAsync(int id)
    {
        return await repository.GetByIdExplicitAsync(id);
    }
    public async Task<bool> TransactionDemoAsync(int id, bool fail)
    {
        return await repository.TransactionDemoAsync(id, fail);
    }
}