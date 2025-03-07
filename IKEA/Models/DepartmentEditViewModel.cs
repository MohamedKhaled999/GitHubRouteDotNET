using System.ComponentModel.DataAnnotations;

namespace IKEA.Models
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage ="Code Is Required !!")]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
