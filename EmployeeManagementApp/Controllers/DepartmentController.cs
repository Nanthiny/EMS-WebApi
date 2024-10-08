using EmployeeManagementApp.Dtos;
using EmployeeManagementApp.Dtos.Request;
using EmployeeManagementApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentRepo _repo;
		public DepartmentController(IDepartmentRepo repo)
		{
			_repo = repo;
		}
		/// <summary>
		/// Create department
		/// </summary>
		/// <param name="departmentDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ResponseMessage> CreateAsync([FromBody] DepartmentCreateRequestDto departmentDto)
		{
			try
			{
				await _repo.CreateDepartmentAsync(departmentDto);
				return ResponseMessage.GetResult(true, "Successfully created...");
			}
			catch (DbUpdateException ex)
			{
				return ResponseMessage.GetResult(false, "Department already exist...");
			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}

		}
		/// <summary>
		/// Delete department
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<ResponseMessage> DeleteAsync([FromQuery] int id)
		{
			try
			{
				if(await _repo.DeleteDepartmentAsync(id))
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
		/// Get departments
		/// </summary>
		/// <returns></returns>
		[HttpGet("get-all")]
		public async Task<ActionResult> GetAllAsync()
		{
			try
			{
				return Ok(await _repo.GetAllDepartmentsAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(500,ex.Message);
			}
		}
		/// <summary>
		/// Get department by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult> GetAsync([FromRoute] int id)
		{
			try
			{
				var entity = await _repo.GetDepartmentAsync(id);
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
		/// update department
		/// </summary>
		/// <param name="id"></param>
		/// <param name="departmentDto"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<ResponseMessage> UpdateAsync([FromRoute] int id, [FromBody] DepartmentCreateRequestDto departmentDto)
		{
			try
			{
				var existingEntity = await _repo.UpdateDepartmentAsync(id, departmentDto);
				if (existingEntity != null)
				{

					return ResponseMessage.GetResult(true, "Successfully updated....");
				}
				else
				{
					return ResponseMessage.GetResult(false, "Update failed");
				}

			}
			catch (DbUpdateException ex)
			{
				return ResponseMessage.GetResult(false, "Department already exist...");
			}
			catch (Exception ex)
			{
				return ResponseMessage.GetResult(false, ex.Message);
			}
			
		}
	}
}
