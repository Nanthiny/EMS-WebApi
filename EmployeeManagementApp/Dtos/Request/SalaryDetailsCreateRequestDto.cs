using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Dtos.Request
{
	public class SalaryDetailsCreateRequestDto
	{
		[Required]
		public int EmployeeId { get; set; }
		[Required]
		public double Salary { get; set; }
		[Required]
		public DateTime EffectiveDate { get; set; }
	}
}
