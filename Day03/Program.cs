using Day03.Models;

Console.WriteLine("===== Employee Payroll System =====");

Console.Write("Enter Employee ID: ");
int id = int.Parse(Console.ReadLine()!);

Console.Write("Enter Employee Name: ");
string name = Console.ReadLine()!;

Console.WriteLine("\nSelect Employee Type:");
Console.WriteLine("1. Full Time");
Console.WriteLine("2. Part Time");
Console.WriteLine("3. Contract");

Console.Write("Enter your choice: ");
int choice = int.Parse(Console.ReadLine()!);

Employee employee;

switch (choice)
{
    case 1:
        Console.Write("Enter Monthly Salary: ");
        double monthlySalary = double.Parse(Console.ReadLine()!);

        employee = new FullTimeEmployee
        {
            Id = id,
            Name = name,
            MonthlySalary = monthlySalary
        };
        break;

    case 2:
        Console.Write("Enter Hourly Rate: ");
        double hourlyRate = double.Parse(Console.ReadLine()!);

        Console.Write("Enter Hours Worked: ");
        int hoursWorked = int.Parse(Console.ReadLine()!);

        employee = new PartTimeEmployee
        {
            Id = id,
            Name = name,
            HourlyRate = hourlyRate,
            HoursWorked = hoursWorked
        };
        break;

    case 3:
        Console.Write("Enter Contract Amount: ");
        double contractAmount = double.Parse(Console.ReadLine()!);

        employee = new ContractEmployee
        {
            Id = id,
            Name = name,
            ContractAmount = contractAmount
        };
        break;

    default:
        Console.WriteLine("Invalid employee type.");
        return;
}

Console.WriteLine("\n===== Payroll Details =====");
Console.WriteLine($"Employee ID: {employee.Id}");
Console.WriteLine($"Employee Name: {employee.Name}");
Console.WriteLine($"Salary: {employee.CalculateSalary()}");