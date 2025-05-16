using Microsoft.EntityFrameworkCore;
using WorkingWithMultipleTable_Prod.Models;

namespace WorkingWithMultipleTable_Prod.Data
{
    public class ApplicationContext : DbContext
    {
       //public ApplicationContext(DbContextOptions options) : base(options) { }
       public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; } // pahla table generate
        public DbSet<DepartmentModel> Departments { get; set; }


    }
}
