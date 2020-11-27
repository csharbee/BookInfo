using BookInfo.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(MainContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _dbSet.AddRangeAsync(Entities);
        }

        public void Delete(T Entity)
        {
            _dbSet.Remove(Entity);
        }

        public void DeleteRange(IEnumerable<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); ;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public void Update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
