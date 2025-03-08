using IKEA.DAL.Models.Departments;
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
        public int Add(Employee entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Employee entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public IEnumerable<Employee> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return _dbContext.Employees.AsNoTracking().ToList();

                return _dbContext.Employees.ToList();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
           return _dbContext.Employees;
        }

        public Employee GetById(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public int Update(Employee entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
