using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistence.Data;
using IKEA.DAL.Persistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;



namespace IKEA.DAL.Persistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext):base(dbContext) {
        
          
        }
        
    }
}
