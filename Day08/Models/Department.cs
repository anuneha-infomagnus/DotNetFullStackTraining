using System.Text.Json.Serialization;
namespace Day08.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
