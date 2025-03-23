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

        public async Task <IEnumerable<T>> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return await _dbContext.Set<T>().Where(E =>E.IsDeleted == false)
                    .AsNoTracking<T>().ToListAsync();


            return await _dbContext.Set<T>().Where(E => E.IsDeleted == false).ToListAsync();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _dbContext.Set<T>().AsNoTracking().Where(E => E.IsDeleted == false);
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
