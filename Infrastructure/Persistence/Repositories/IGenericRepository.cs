using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal interface IGenericRepository<T> 
        where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync();




    }
}
