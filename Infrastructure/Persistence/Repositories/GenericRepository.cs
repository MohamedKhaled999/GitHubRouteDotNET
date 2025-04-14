using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {

        protected readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext) { _storeContext = storeContext; }
        public async Task AddAsync(TEntity entity)
                                            =>await _storeContext.AddAsync(entity);

       

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges=false)
                                    =>  trackChanges? await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync()
                                       :
                                        await _storeContext.Set<TEntity>().ToListAsync();


        public async Task<TEntity?> GetAsync(TKey id)
                                                => await _storeContext.Set<TEntity>().FindAsync(id);

        public void Delete(TEntity entity)
                                                => _storeContext.Remove(entity);

        public void Update(TEntity entity)
                                                => _storeContext.Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(Specifications<TEntity> specifications)
        {
            return await ApplySpecifications(specifications).ToListAsync();
        }

        public async Task<TEntity> GetByIdSpecificationAsync(Specifications<TEntity> specifications)
        {
            return await ApplySpecifications(specifications).FirstOrDefaultAsync();

        }
        private IQueryable<TEntity> ApplySpecifications(Specifications<TEntity> specifications)
            => SpecificationEvaluator.GetQuery(_storeContext.Set<TEntity>(), specifications);

        public async Task<int> GetCountAsync(Specifications<TEntity> specifications)
        => await ApplySpecifications(specifications).CountAsync();
    }
}
