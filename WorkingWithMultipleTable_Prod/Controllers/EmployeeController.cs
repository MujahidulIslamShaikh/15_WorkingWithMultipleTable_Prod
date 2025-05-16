using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WorkingWithMultipleTable_Prod.Data;
using WorkingWithMultipleTable_Prod.Models;
using WorkingWithMultipleTable_Prod.Models.ViewModel;

namespace WorkingWithMultipleTable_Prod.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext Db_context;
        public EmployeeController(ApplicationContext applicationContext)
        {
            this.Db_context = applicationContext;
        }


        public IActionResult Index()
        {
            // ============ Using Merge Model ==============
            //EmpDepViewModel emp = new EmpDepViewModel();
            //emp.Employee = Db_context.Employees.ToList();
            //emp.Department = Db_context.Departments.ToList();

            // ============ Using Sql Merge Model ========================
            //EmpDepViewModel emp = new EmpDepViewModel();
            //emp.Employee = Db_context.Employees.FromSqlRaw("select * from Employees").ToList();
            //emp.Department = Db_context.Departments.FromSqlRaw("select * from Departments").ToList();

            // ============ Using Join Model ========================
            //var data = ( from e in Db_context.Employees
            //             join d in Db_context.Departments
            //             on e.DepId equals d.DepId
            //select new EmpDepKiAllProperties
            //    {
            //        EmpId=e.EmpId,
            //        Fname=e.Fname,
            //        Gender=e.Gender,
            //        DepId=e.DepId,
            //        DepName=d.DepName,
            //        DepCoded=d.DepCoded
            //    }
            //    ).ToList();
            //EmployeeModel e = new EmployeeModel();
            //EmployeeModel e = new EmployeeModel();


            //var data = Db_context.empDepKiAllProperties.FromSqlRaw("SELECT" +
            //    " e.EmpId, e.Fname, d.DepId, d.DepName FROM Employee e JOIN Department d" +
            //    "ON e.DepId = d.DepId;");
            var data = Db_context.empDepKiAllProperties.FromSqlRaw(
    "SELECT e.EmpId, e.Fname,e.Gender, d.DepId, d.DepName, d.DepCoded FROM Employees e JOIN Departments d ON e.DepId = d.DepId;"
);


            //return View(emp);
            //return View(data);
            return View(data);
        }
    }
}
