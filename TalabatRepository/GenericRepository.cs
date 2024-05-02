using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specification;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {       
            return (IReadOnlyList<T>) await _dbContext.Set<T>().ToListAsync();
        }

        public  async Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecification<T> specification)
        {
           return await GetSpec(specification).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbContext.Set<T>().Where(P=>P.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsyncWithSpec(ISpecification<T> specification)
        {
            return await GetSpec(specification).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> specification)
        {
          return  await GetSpec(specification).CountAsync();
         
        }

        private  IQueryable<T> GetSpec(ISpecification<T> specification)
        {
            return  SpecificationEvaluator<T>.BuildQuery(_dbContext.Set<T>(), specification);
        }


    }
}
