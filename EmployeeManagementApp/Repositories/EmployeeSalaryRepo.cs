using EmployeeManagementApp.DBContext;
using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Repositories
{
	public class EmployeeSalaryRepo : CrudRepo<EmployeeSalaryDetail>, ISalaryDetailsRepo
	{
		public EmployeeSalaryRepo(SystemDbContext dbContext) : base(dbContext)
		{

		}
		public async Task<EmployeeSalaryDetail> CreateEmployeeSalaryAsync(SalaryDetailsCreateRequestDto salaryDto)
		{
			var salary = new EmployeeSalaryDetail
			{
				EmployeeId = salaryDto.EmployeeId,
				EffectiveDate = salaryDto.EffectiveDate,
				Salary = salaryDto.Salary
			};
			return await CreateAsync(salary);
		}

		public async Task<bool> DeleteEmployeeSalaryAsync(int id)
		{
			return await DeleteAsync(id);
		}

		public async Task<IEnumerable<EmployeeSalaryDto>> GetAllSalaryDetailsAsync()
		{		
			//get salary details of active employees
			var query = await (from salary in _dbContext.EmployeeSalaryDetails.AsQueryable()
							   join emp in _dbContext.Employees.AsQueryable().Where(x=>x.IsActive==true) on salary.EmployeeId equals emp.EmployeeId
							   select new EmployeeSalaryDto
							   {
								 EmployeeId= emp.EmployeeId,
								 EmployeeNumber= emp.EmployeeNumber,
								 Salary=salary.Salary,
								 EffectiveDate=salary.EffectiveDate,
								 EmployeeSalaryDetailsId= salary.EmployeeSalaryDetailId
							   }).ToListAsync();
			return query;
		}

		public async Task<EmployeeSalaryDetail> GetEmployeeSalaryAsync(int id)
		{
			return await GetAsync(id);
		}

		public async Task<EmployeeSalaryDetail> UpdateEmployeeSalaryAsync(int id, SalaryDetailsCreateRequestDto employeeDto)
		{
			var entity = await GetAsync(id);
			if (entity != null)
			{
				entity.EmployeeId = employeeDto.EmployeeId;
				entity.Salary = employeeDto.Salary;
				entity.EffectiveDate = employeeDto.EffectiveDate;
				entity = await UpdateAsync(entity);
			}
			return entity;
		}
	}
}
