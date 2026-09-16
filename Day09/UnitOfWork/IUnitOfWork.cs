using Day09.Repositories;

namespace Day09.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<Models.Employee> Employees { get; }
    IRepository<Models.Department> Departments { get; }

    Task<int> SaveChangesAsync();
}