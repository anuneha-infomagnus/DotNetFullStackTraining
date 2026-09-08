using System.ComponentModel.DataAnnotations;
namespace Day07.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
        
    }
}
