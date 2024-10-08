using EmployeeManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApp.DBContext
{
	public class SystemDbContext: DbContext
	{
		public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>()
				.HasMany(e => e.Employees)
				.WithOne(e => e.Department)
				.HasForeignKey(e => e.DepartmentId)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.HasOne(e => e.EmployeeSalaryDetail)
				.WithOne(e => e.Employee)
				.HasForeignKey<EmployeeSalaryDetail>(e=>e.EmployeeId)
				.IsRequired();
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }
	}
}
