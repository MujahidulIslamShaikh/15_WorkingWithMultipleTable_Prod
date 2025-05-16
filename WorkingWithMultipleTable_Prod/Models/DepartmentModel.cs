using System.ComponentModel.DataAnnotations;

namespace WorkingWithMultipleTable_Prod.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepId { get; set; }
        public string DepName { get; set; } = default!;
        public string DepCoded { get; set; } = default!;
        
    }
}
