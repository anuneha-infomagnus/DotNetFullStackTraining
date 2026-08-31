using Day05.Filters;
using Day05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day05.Controllers
{

    [MyActionFilter]
    public class EmployeeController : Controller
    {
        // Temporary in-memory employee list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Anu",
                Email = "anu@gmail.com",
                Salary = 50000,
                Department = "IT"
            },

            new Employee
            {
                Id = 2,
                Name = "Ravi",
                Email = "ravi@gmail.com",
                Salary = 60000,
                Department = "HR"
            },

            new Employee
            {
                Id = 3,
                Name = "Priya",
                Email = "priya@gmail.com",
                Salary = 55000,
                Department = "Finance"
            }
        };


        // =========================
        // INDEX
        // =========================

        // GET: /Employee/Index
        public IActionResult Index()
        {
            return View(employees);
        }


        // =========================
        // CREATE
        // =========================

        // GET: /Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            employee.Id = employees.Max(e => e.Id) + 1;

            employees.Add(employee);

            return RedirectToAction(nameof(Index));
        }


        // =========================
        // EDIT
        // =========================

        // GET: /Employee/Edit/1
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: /Employee/Edit
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var existingEmployee =
                employees.FirstOrDefault(e => e.Id == employee.Id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Department = employee.Department;

            return RedirectToAction(nameof(Index));
        }


        // =========================
        // DELETE
        // =========================

        // GET: /Employee/Delete/1
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: /Employee/Delete/1
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}