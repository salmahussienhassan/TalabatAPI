using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity

    {

        //GetById (Filteration)
        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
         
        }


        //GetAll
        public BaseSpecification()
        {
 
        }
        //Sorting
        public void AddOrderBy(Expression<Func<T,object>> SortValue)
        {
            this.OrderBy = SortValue;
        }

        public void AddOrderDescBy(Expression<Func<T, object>> SortValue)
        {
            this.OrderByDesc = SortValue;
        }

        //Pagination

    public void ApplyPagination(int skip,int take)
        {
            this.Take = take;
            this.Skip = skip;
            this.IsPaginationEnable = true;
        }


        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public bool IsPaginationEnable { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }


    }
    
    
}
