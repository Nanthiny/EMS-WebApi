using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeSalaryController : ControllerBase
	{
		private readonly ISalaryDetailsRepo _repo;
		public EmployeeSalaryController(ISalaryDetailsRepo repo)
		{
			_repo = repo;
		}
		/// <summary>
		/// Create Employee Salary Details
		/// </summary>
		/// <param name="employeeSalary"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ResponseMessage> CreateAsync([FromBody] SalaryDetailsCreateRequestDto employeeSalary)
		{
			try
			{
				await _repo.CreateEmployeeSalaryAsync(employeeSalary);
				return ResponseMessage.GetResult(true, "Successfully created...");
			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}

		}
		/// <summary>
		/// Get All Employee Salary Details
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all")]
		public async Task<ActionResult> GetAllAsync()
		{
			try
			{
				return Ok(await _repo.GetAllSalaryDetailsAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		/// <summary>
		/// Delete employee salary
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<ResponseMessage> DeleteAsync([FromQuery] int id)
		{
			try
			{
				if (await _repo.DeleteEmployeeSalaryAsync(id))
				{
					return ResponseMessage.GetResult(true, "Deleted Successfully...");
				}
				return ResponseMessage.GetResult(true, "Delete Failed...");
			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}
		}
		/// <summary>
		/// Get Employee Salary Details By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult> GetAsync([FromRoute] int id)
		{
			try
			{
				var entity = await _repo.GetEmployeeSalaryAsync(id);
				if (entity == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(entity);
				}

			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		/// <summary>
		/// Update Employee Salary Details
		/// </summary>
		/// <param name="id"></param>
		/// <param name="salaryDto"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<ResponseMessage> UpdateAsync([FromRoute] int id, [FromBody] SalaryDetailsCreateRequestDto salaryDto)
		{
			try
			{
				var existingEntity = await _repo.UpdateEmployeeSalaryAsync(id, salaryDto);
				if (existingEntity != null)
				{

					return ResponseMessage.GetResult(true, "Successfully updated ...");
				}
				else
				{
					return ResponseMessage.GetResult(false, "Update failed ...");
				}

			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}
		}
	}
}
