using Day09.Data;
using Day09.Models;
using Day09.Repositories;

namespace Day09.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    public IRepository<Employee> Employees { get; }
    public IRepository<Department> Departments { get; }

    public UnitOfWork(
        AppDbContext context,
        IRepository<Employee> employees,
        IRepository<Department> departments)
    {
        this.context = context;
        Employees = employees;
        Departments = departments;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}