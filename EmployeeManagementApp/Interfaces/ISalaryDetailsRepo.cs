using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Interfaces
{
	public interface ISalaryDetailsRepo
	{
		Task<EmployeeSalaryDetail> CreateEmployeeSalaryAsync(SalaryDetailsCreateRequestDto departmentDto);
		Task<EmployeeSalaryDetail> UpdateEmployeeSalaryAsync(int id, SalaryDetailsCreateRequestDto employeeDto);
		Task<EmployeeSalaryDetail> GetEmployeeSalaryAsync(int id);
		Task<IEnumerable<EmployeeSalaryDto>> GetAllSalaryDetailsAsync();
		Task<bool> DeleteEmployeeSalaryAsync(int id);

	}
}
