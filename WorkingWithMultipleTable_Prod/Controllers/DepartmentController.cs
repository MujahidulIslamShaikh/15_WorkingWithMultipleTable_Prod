using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkingWithMultipleTable_Prod.Data;

namespace WorkingWithMultipleTable_Prod.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationContext context;
        public DepartmentController(ApplicationContext context)
        {
            this.context = context;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
