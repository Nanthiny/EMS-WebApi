using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepo _repo;
		public EmployeeController(IEmployeeRepo repo) {
			_repo = repo;
		}
		/// <summary>
		/// Create new employee
		/// </summary>
		/// <param name="employee"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ResponseMessage> CreateAsync([FromBody] EmployeeCreateRequestDto employee)
		{			
			try
			{
				await _repo.CreateEmployeeAsync(employee);
				return ResponseMessage.GetResult(true, "Successfully created...");
			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}

		}
		/// <summary>
		/// Delete Employee
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<ResponseMessage> DeleteAsync([FromQuery] int id)
		{
			try
			{
				if(await _repo.DeleteEmployeeAsync(id))
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
		/// Get Employees
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all")]
		public async Task<ActionResult> GetAllAsync()
		{
			try
			{
				return Ok(await _repo.GetAllEmployeeAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		/// <summary>
		/// Get Employee by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult> GetAsync([FromRoute] int id)
		{
			try
			{
				var entity = await _repo.GetEmployeeAsync(id);
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
		/// Update Employee
		/// </summary>
		/// <param name="id"></param>
		/// <param name="employee"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<ResponseMessage> UpdateAsync([FromRoute] int id, [FromBody] EmployeeCreateRequestDto employee)
		{
			try
			{
				var existingEntity = await _repo.UpdateEmployeeAsync(id,employee);
				if (existingEntity != null)
				{	

					return ResponseMessage.GetResult(true, "Successfully updated..");
				}
				else
				{
					return ResponseMessage.GetResult(false, "Update failed...");
				}

			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}
		}
	}
}
