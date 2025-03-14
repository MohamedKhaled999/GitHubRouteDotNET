using IKEA.BLL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeToReturnDTO> GetEmployees();
        EmployeeDetailsDTO? GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDTO createdEmployeeDTO);
        int UpdateEmployee(UpdatedEmployeeDTO updatedEmployeeDTO);
        bool DeleteEmployee(int id);
    }
}
