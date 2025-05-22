using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{   
    // base        critera     include
    //context.product.where().include()....
    public abstract class Specifications<T> 
        where T : class
    {
       public Specifications(Expression<Func<T, bool>> critera)
                          => Critera = critera;

        public Expression<Func<T,bool>>? Critera { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();

        #region Filteration && Sorting
        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }
        #endregion

        #region Pagination
        public int Take {  get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }
        #endregion


        protected void AddInclude(Expression<Func<T, object>> expression) 
                          => IncludeExpressions.Add(expression);

        protected void SetOrderBy(Expression<Func<T, object>> expression) 
            => OrderBy = expression;

        protected void SetOrderByDescending(Expression<Func<T, object>> expression)
           => OrderBy = expression;

        protected void ApplyPagination(int pageIndex,int pageSize )
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex-1) * pageSize;


        }

    }
}
