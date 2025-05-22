using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record PaginatedResult<T>(int PageIndex, int PageSize ,int Count , IEnumerable<T> Data) 
    {
    }
}
