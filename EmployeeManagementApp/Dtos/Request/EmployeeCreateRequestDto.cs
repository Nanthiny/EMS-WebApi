using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Dtos.Request
{
	public class EmployeeCreateRequestDto
	{
		[Required]
		public string EmployeeName { get; set; }
		[Required]
		public string EmployeeNumber { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string EmailAddress { get; set; }
		[Required]
		[MinLength(6)]
		[MaxLength(20)]
		[Phone(ErrorMessage = "Invalid Phone Number.")]
		public string Phone { get; set; }
		[Required]
		public string JobTitle { get; set; }
		[Required]
		public DateTime JoinedDate { get; set; }
		[Required]
		public int DepartmentId { get; set; }
		
	}
}
