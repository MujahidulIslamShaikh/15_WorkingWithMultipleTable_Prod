using Microsoft.AspNetCore.Mvc;
using WorkingWithMultipleTable_Prod.Data;
using WorkingWithMultipleTable_Prod.Models.ViewModel;

namespace WorkingWithMultipleTable_Prod.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            EmpDepViewModel emp = new EmpDepViewModel();

            var empData = context.Employees.ToList();
            var depData = context.Departments.ToList();

            emp.Employee = empData;
            emp.Department = depData;

            //return View(empData);
            return View(emp);
        }
    }
}
