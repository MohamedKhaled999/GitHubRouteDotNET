using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF.models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }

        //work
        //
        [InverseProperty(nameof(models.Employee.Department))]

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //manage
        //
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        [InverseProperty(nameof(models.Employee.DepartmentManage))]
        public virtual Employee Manager { get; set; } = null!;

    }
}
