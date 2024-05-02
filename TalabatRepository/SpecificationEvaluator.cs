using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> BuildQuery(IQueryable<T> InputQuery,ISpecification<T> specification)
        {
            var Query = InputQuery;

            if(specification.Criteria is not null)
            {
               Query= Query.Where(specification.Criteria);

            }

            if(specification.OrderBy is not null)
            {
                Query= Query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDesc is not null)
            {
                Query = Query.OrderByDescending(specification.OrderByDesc);
            }

            if(specification.IsPaginationEnable)
            {
            Query=Query.Take(specification.Take).Skip(specification.Skip);
            }

            Query = specification.IncludeExpressions
                    .Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));

            return Query;
        }
    }
}
