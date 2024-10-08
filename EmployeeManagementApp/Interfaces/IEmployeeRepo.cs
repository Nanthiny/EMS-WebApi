using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Interfaces
{
	public interface IEmployeeRepo
	{
		Task<Employee> CreateEmployeeAsync(EmployeeCreateRequestDto employeeDto);
		Task<Employee> UpdateEmployeeAsync(int id, EmployeeCreateRequestDto employeeDto);
		Task<Employee> GetEmployeeAsync(int id);
		Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync();
		Task<bool> DeleteEmployeeAsync(int id);
		
	}
}
