using EmployeeManagementApp.DBContext;
using EmployeeManagementApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.Repositories
{
	public class CrudRepo<T> : ICrudRepo<T> where T:class
	{
		protected readonly SystemDbContext _dbContext;
		public CrudRepo(SystemDbContext dbContext)
		{
			_dbContext= dbContext;
		}
		public async Task<T> CreateAsync(T entity)
		{
			 await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int Id)
		{
			var entity= await GetAsync(Id);
			if(entity != null)
			{
				_dbContext.Remove(entity); 
				await _dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var entityList=_dbContext.Set<T>();
			return await entityList.ToListAsync();
		}

		public async Task<T> GetAsync(int id)
		{
			return await _dbContext.FindAsync<T>(id);
		}

		public  async Task<T> UpdateAsync(T entity)
		{
			 _dbContext.Update(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}
	}
}
