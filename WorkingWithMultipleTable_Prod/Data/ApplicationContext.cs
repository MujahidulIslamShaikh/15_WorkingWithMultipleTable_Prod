using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WorkingWithMultipleTable_Prod.Models;
using WorkingWithMultipleTable_Prod.Models.ViewModel;

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

        [NotMapped] // ==> isse migration nahi hoga property ka kyu ke hum ko sirf query ko execute karane ke liye 
                              // ye property likhe hai.
        public DbSet<EmpDepKiAllProperties> empDepKiAllProperties { get; set; }


    }
}
