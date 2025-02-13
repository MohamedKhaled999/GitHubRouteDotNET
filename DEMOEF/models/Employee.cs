using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF.models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        
        //not related to DB

        //[StringLength(50,MinimumLength =10)]
        //[MinLength(50)]
        //[Length(10,50)]
        [Column(TypeName="nvarchar(50)")]
        [Length(10,50)]

        public string? Name { get; set; }

        [Column(TypeName ="decimal(18,2)")]

        public decimal Salary{ get; set; }

        [Range(22,60)]
        [AllowedValues(20,21,22,23)]
        [DeniedValues(10,15)]
        public int? Age { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }


        [Phone]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; } = string.Empty;


        // work one
        //
        [ForeignKey("Department")]
        public int? DepartmentDeptId { get; set; }

        [InverseProperty(nameof(models.Department.Employees))]

        public virtual Department? Department { get; set; }

        // manage one
        //

        [InverseProperty(nameof(models.Department.Manager))]
        public virtual Department? DepartmentManage { get; set; }

    }
}
