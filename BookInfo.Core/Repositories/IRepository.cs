using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T Entity);
        Task AddRangeAsync(IEnumerable<T> Entities);
        void Delete(T Entity);
        void DeleteRange(IEnumerable<T> Entities);
        void Update(T Entity);
    }
}
