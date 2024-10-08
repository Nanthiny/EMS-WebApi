using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
	public class Department
	{
		[Key]
		public int DepartmentId { get; set; }
		[Required]
		public string DepartmentName { get; set; }
		public IEnumerable<Employee>? Employees { get; set; }
	}
}
