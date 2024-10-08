using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Interfaces
{
	public interface IDepartmentRepo
	{
		Task<Department> CreateDepartmentAsync(DepartmentCreateRequestDto departmentDto);
		Task<Department> UpdateDepartmentAsync(int id, DepartmentCreateRequestDto departmentDto);
		Task<Department> GetDepartmentAsync(int id);
		Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
		Task<bool> DeleteDepartmentAsync(int id);
	}
}
