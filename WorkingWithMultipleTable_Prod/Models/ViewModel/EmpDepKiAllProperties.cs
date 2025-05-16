using System.ComponentModel.DataAnnotations;

namespace WorkingWithMultipleTable_Prod.Models.ViewModel
{
    public class EmpDepKiAllProperties
    {
        [Key]
        public int EmpId { get; set; } 
        public int DepId { get; set; }
        public string Fname { get; set; } = default!;
        public string? Gender { get; set; }
        public string DepName { get; set; } = default!;
        public string DepCoded { get; set; } = default!;

    }
}
