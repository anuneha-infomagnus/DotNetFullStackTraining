using System.ComponentModel.DataAnnotations;

namespace Day05.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Department { get; set; } = string.Empty;

        [Range(10000, 10000000)]
        public decimal Salary { get; set; }
    }
}