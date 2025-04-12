using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifications<T> 
        where T : class
    {
       public Specifications(Expression<Func<T, bool>> critera)
                          => Critera = critera;

        public Expression<Func<T,bool>>? Critera { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();

        protected void AddInclude(Expression<Func<T, object>> expression) 
                          => IncludeExpressions.Add(expression);
        
    }
}
