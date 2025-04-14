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
            if(specifications.Critera is not null)
            query = query.Where(specifications.Critera);

            query = specifications.IncludeExpressions.Aggregate(query, (currentQuery, nextQueryExpression) => currentQuery.Include(nextQueryExpression));

            if (specifications.OrderBy is not null)
            {
                 query=query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }

            if (specifications.IsPaginated)
            {
               query =  query.Skip(specifications.Skip).Take(specifications.Take);
                
            }

            return query;
        }
    }
}
