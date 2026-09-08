using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day07.Data;
using Day07.Models;

namespace Day07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DepartmentController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return Ok(department);
        }
    }
}
