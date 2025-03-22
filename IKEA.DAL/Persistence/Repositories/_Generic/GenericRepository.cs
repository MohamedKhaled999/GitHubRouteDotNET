using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Repositories._Generic
{
    public class GenericRepository<T> :IGenericRepository<T>
        where T : ModelBase
    {
       private protected readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbContext.Update(entity);
        }

        public IEnumerable<T> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return _dbContext.Set<T>().Where(E =>E.IsDeleted == false)
                    .AsNoTracking<T>().ToList();


            return _dbContext.Set<T>().Where(E => E.IsDeleted == false).ToList();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbContext.Set<T>().Where(E => E.IsDeleted == false);
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
