using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WorkingWithMultipleTable_Prod.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        public string Fname { get; set; } = default!;
        public string? Gender { get; set; }
        public int DepId { get; set; }
        [ForeignKey("DepId")]  // dep table ki primary key , Employee ki foreign key
        public DepartmentModel Department { get; set; }

    }
}
