namespace Day03.Models;

public class PartTimeEmployee : Employee
{
    public double HourlyRate { get; set; }

    public int HoursWorked { get; set; }

    public override double CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}