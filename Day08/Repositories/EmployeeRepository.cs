using System.Data;
using Day08.Data;
using Day08.Models;
using Microsoft.EntityFrameworkCore;

namespace Day08.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext context;

    public EmployeeRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<List<Employee>> GetAllAsync()
    {
        return await context.Employees.ToListAsync();
    }
    public async Task<List<Employee>> SearchAsync(string name)
    {
        return await context.Employees
        .Include(e => e.Department)
        .Where(e => e.Name.Contains(name))
        .ToListAsync();
    }
    public async Task<List<Employee>> GetByDepartmentAsync(int departmentId)
    {
        return await context.Employees
            .Include(e => e.Department)
            .Where(e => e.DepartmentId == departmentId)
            .ToListAsync();
    }
    public async Task<Employee?> GetByIdLazyAsync(int id)
    {
        return await context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == id);
    }
    public async Task<Employee?> GetByIdExplicitAsync(int id)
    {
        var employee = await context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == id);

        if (employee != null)
        {
            await context.Entry(employee)
                .Reference(e => e.Department)
                .LoadAsync();
        }

        return employee;
    }
    public async Task<bool> TransactionDemoAsync(int id, bool fail)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(
                IsolationLevel.Serializable);

        try
        {
            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
                return false;

            employee.Salary += 1000;

            await context.SaveChangesAsync();

            // Deliberately fail when testing rollback
            if (fail)
                throw new Exception("Demo failure - testing rollback.");

            employee.Salary += 2000;

            await context.SaveChangesAsync();

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}