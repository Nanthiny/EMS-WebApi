using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
	public class EmployeeSalaryDetail
	{
		[Key]
		public int EmployeeSalaryDetailId { get; set; }
		[Required]
		public int EmployeeId { get; set; }
		[Required]
		public double Salary { get; set; }
		[Required]
		public DateTime EffectiveDate { get; set; }
		public Employee Employee { get; set; } = null!;

	}
}
