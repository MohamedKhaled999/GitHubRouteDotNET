using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery , Specifications<T> specifications ) where T : class
        {
            var query = inputQuery;
            query = query.Where(specifications.Critera);

            specifications.IncludeExpressions.Aggregate(query, (currentQuery, nextQueryExpression) => query.Include(nextQueryExpression));

            return query;
        }
    }
}
