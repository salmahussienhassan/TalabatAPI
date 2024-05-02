using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T:BaseEntity
    {

        #region WithoutSpec
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        #endregion

        #region WithSpec

        public Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecification<T> specification);
        public Task<T> GetByIdAsyncWithSpec(ISpecification<T> specification);

        public Task<int> GetCountWithSpecAsync(ISpecification<T> specification);
        #endregion

    }
}
