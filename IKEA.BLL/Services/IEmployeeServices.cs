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
        Task<IEnumerable<EmployeeToReturnDTO>> GetEmployeesAsync(string? search= null);
        Task<EmployeeDetailsDTO?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(CreatedEmployeeDTO createdEmployeeDTO);
        Task<int> UpdateEmployeeAsync(UpdatedEmployeeDTO updatedEmployeeDTO);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
