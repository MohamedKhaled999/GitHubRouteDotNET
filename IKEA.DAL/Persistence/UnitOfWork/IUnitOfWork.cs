using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public  IEmployeeRepository EmployeeRepository { get; }
        public  IDepartmentRepository DepartmentRepository { get;  }

       Task< int> CompleteAsync(); 

    }
}
