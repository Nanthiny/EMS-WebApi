using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
	/// <summary>
	/// Model for employee entity table
	/// </summary>
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }
		[Required]
		public string EmployeeName { get; set; }
		[Required]
		public string EmployeeNumber { get; set; } = null!;
		[Required]		
		public string EmailAddress { get; set; }
		[Required]
		[MinLength(6)]
		[MaxLength(20)]
		public string Phone { get; set; }
		
		[Required]
		public string JobTitle { get; set; }
		[Required]
		public DateTime JoinedDate { get; set; }
		public int DepartmentId { get; set; }
		public int? EmployeeSalaryDetailId { get; set; }
		public Department Department { get; set; } = null!;
		public bool IsActive { get; set; }
		public EmployeeSalaryDetail? EmployeeSalaryDetail { get; set; }
	}
}
