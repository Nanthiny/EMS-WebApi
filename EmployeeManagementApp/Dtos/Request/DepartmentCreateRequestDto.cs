using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Dtos.Request
{
	public class DepartmentCreateRequestDto
	{
		[Required]
		public string DepartmentName { get; set; }
	}
}
