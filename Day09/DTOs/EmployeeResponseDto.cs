namespace Day09.DTOs;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}