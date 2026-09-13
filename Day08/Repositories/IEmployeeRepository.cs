using Day08.Models;

namespace Day08.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<List<Employee>> SearchAsync(string name);
        Task<List<Employee>> GetByDepartmentAsync(int departmentId);
        Task<Employee?> GetByIdLazyAsync(int id);
        Task<Employee?> GetByIdExplicitAsync(int id);
        Task<bool> TransactionDemoAsync(int id, bool fail);
    }
}
