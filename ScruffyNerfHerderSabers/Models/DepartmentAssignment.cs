using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScruffyNerfHerderSabers.Models
{
    public class DepartmentAssignment
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [StringLength(50)]
        [Display(Name = "Department Location")]
        public string Location { get; set; }

        public virtual Employee Employee { get; set; }
    }
}