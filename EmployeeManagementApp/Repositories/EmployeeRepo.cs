using EmployeeManagementApp.DBContext;
using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Numerics;

namespace EmployeeManagementApp.Repositories
{
	public class EmployeeRepo:CrudRepo<Employee>,IEmployeeRepo
	{
		
		
		public EmployeeRepo(SystemDbContext dbContext):base(dbContext)
		{
			
		}
		public async Task<Employee> CreateEmployeeAsync(EmployeeCreateRequestDto employeeDto)
		{
			Employee employee = new Employee
			{
				EmployeeName = employeeDto.EmployeeName,
				EmployeeNumber = employeeDto.EmployeeNumber,
				EmailAddress = employeeDto.EmailAddress,
				JobTitle= employeeDto.JobTitle,			
				DepartmentId= employeeDto.DepartmentId,
				JoinedDate= employeeDto.JoinedDate,
				Phone= employeeDto.Phone,
				IsActive=true
			};
			
			return (await CreateAsync(employee));
		}

		public async Task<bool> DeleteEmployeeAsync(int id)
		{
			//update the entity active satae to false state
			var employee=await GetEmployeeAsync(id);
			employee.IsActive = false;
			var entity=await UpdateAsync(employee);
			return !(entity.IsActive);				
		}

		public async Task<IEnumerable<EmployeeDto>> GetAllEmployeeAsync()
		{
			var empls=await GetAllAsync();
			var query = from employee in empls.Where(x=>x.IsActive==true)
						 join department in _dbContext.Departments.AsQueryable() on employee.DepartmentId equals department.DepartmentId
						 select new EmployeeDto
						 {
							 EmployeeId=employee.EmployeeId,
							 EmployeeName = employee.EmployeeName,
							 EmployeeNumber = employee.EmployeeNumber,
							 EmailAddress = employee.EmailAddress,
							 JobTitle = employee.JobTitle,						
							 DepartmentId = employee.DepartmentId,
							 JoinedDate = employee.JoinedDate,
							 Phone = employee.Phone,
							 DepartmentName = department.DepartmentName
			
						 };
		
			return query;
		}

		public async Task<Employee> GetEmployeeAsync(int id)
		{
			return await GetAsync(id);
		}

		public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeCreateRequestDto employeeDto)
		{
			var entity=await GetAsync(id);
			if(entity!=null) {
				entity.EmployeeName = employeeDto.EmployeeName;
				entity.EmployeeNumber = employeeDto.EmployeeNumber;
				entity.EmailAddress = employeeDto.EmailAddress;
				entity.JobTitle = employeeDto.JobTitle;				
				entity.DepartmentId = employeeDto.DepartmentId;
				entity.JoinedDate = employeeDto.JoinedDate;
				entity.Phone = employeeDto.Phone;
			    entity=await UpdateAsync(entity);			 
			}
			return entity;
		}
	}
}
