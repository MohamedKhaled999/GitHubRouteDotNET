using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Repositories.Departments
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        IEnumerable<Department> GetAll(bool withTracking = true);
        IQueryable<Department> GetAllAsQueryable();

        Department GetById(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);
    }
}
