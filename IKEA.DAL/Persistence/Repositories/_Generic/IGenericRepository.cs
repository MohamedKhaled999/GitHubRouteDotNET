using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {

       Task<IEnumerable<T>> GetAll(bool withTracking = true);
        IQueryable<T> GetAllAsQueryable();
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
