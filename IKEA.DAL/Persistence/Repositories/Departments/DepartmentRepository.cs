using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Repositories.Departments
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Department entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return _dbContext.Departments.AsNoTracking().ToList();

                return _dbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
