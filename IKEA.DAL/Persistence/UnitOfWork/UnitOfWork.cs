using IKEA.DAL.Persistence.Data;
using IKEA.DAL.Persistence.Data.DataSeed;
using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        public IEmployeeRepository EmployeeRepository { 
            get 
            {
                return new EmployeeRepository(_context);
            }
        }
        public IDepartmentRepository DepartmentRepository { 
            get 
            {
              return  new DepartmentRepository(_context);
            } 
        }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            
            _context = context;
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
