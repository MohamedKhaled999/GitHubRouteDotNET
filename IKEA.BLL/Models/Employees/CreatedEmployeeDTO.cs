using IKEA.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Employees
{
    public class CreatedEmployeeDTO
    {
        [MaxLength(50, ErrorMessage = "Max Length of Name is 50 chars")]
        [MinLength(5, ErrorMessage = "Min Length of Name is 50 chars")]
        public string Name { get; set; } = null!;
        [Range(22,30)]
        public int? Age { get; set; }
        [RegularExpression(@"^\d+-\w+-\w+-\w+$",
            ErrorMessage = "123-street-city-country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        [Display(Name="Hire Date")]
        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
    }
}
