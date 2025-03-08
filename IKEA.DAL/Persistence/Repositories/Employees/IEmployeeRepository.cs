using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Repositories.Employees
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
       
    }
}
