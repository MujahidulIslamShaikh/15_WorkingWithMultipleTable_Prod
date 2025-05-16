using System.Text;
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
        private static string EveryFirstCharCapital(string input)  // ye mothod ko hum jaha jaha chahe call karsakte.
        {
                StringBuilder sb = new StringBuilder();   // isme 'sb' me appned karege .
            if (!string.IsNullOrEmpty(input))
            {
                var data = input.Split(' '); // ye indexing kardega 
                for(int i=0; i<data.Length; i++)
                {
                    sb.Append(data[i].First().ToString().ToUpper() + data[i].Substring(1) + " ");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
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

            //================ FromSqlRaw Join ================
            //var data = Db_context.empDepKiAllProperties.FromSqlRaw(
            //"SELECT e.EmpId, e.Fname,e.Gender, d.DepId, d.DepName, d.DepCoded FROM Employees e JOIN Departments d ON e.DepId = d.DepId;"
            //);
            //============= Procedural Way ===================
            //var empdata = Db_context.Employees.FromSqlRaw("exec GetEmpList");
            //var depdata = Db_context.Departments.FromSqlRaw("exec GetDepList");
            var data = Db_context.empDepKiAllProperties.FromSqlRaw("exec GetEmpDepList");

            //return View(emp);
            return View(data);
            //return View(empdata);
            //return View(depdata);
        }
    }
}
