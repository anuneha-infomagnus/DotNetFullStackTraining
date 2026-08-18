using System;
using System.Collections.Generic;

Console.WriteLine("=== Employee Management System ===");

List<Employee> employees = new List<Employee>();

Employee employee1 = new Employee
{
    Id = 101,
    Name = "Anu",
    Department = "IT",
    Salary = 50000
};

Employee employee2 = new Employee
{
    Id = 102,
    Name = "Rahul",
    Department = "HR",
    Salary = 45000
};

Employee employee3 = new Employee
{
    Id = 103,
    Name = "Priya",
    Department = "Finance",
    Salary = 55000
};

employees.Add(employee1);
employees.Add(employee2);
employees.Add(employee3);

Console.WriteLine("\nEmployee Details:");

foreach (Employee employee in employees)
{
    Console.WriteLine(
        $"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}"
    );
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public double Salary { get; set; }
}