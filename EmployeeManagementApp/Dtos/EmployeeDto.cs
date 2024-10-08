using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Dtos
{
	public class EmployeeDto
	{

		public int EmployeeId { get; set; }
		public string EmployeeName { get; set; }

		public string EmployeeNumber { get; set; }

		public string EmailAddress { get; set; }
		
		public string Phone { get; set; }	
	
		public string JobTitle { get; set; }
		
		public DateTime JoinedDate { get; set; }
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int? EmployeeSalaryDetailId { get; set; }
	}
}
