using BookInfo.Core;
using BookInfo.Core.Repositories;
using BookInfo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task AddAsync(T Entity)
        {
            await _repository.AddAsync(Entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await _repository.AddRangeAsync(Entities);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(T Entity)
        {
            _repository.Delete(Entity);
            _unitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<T> Entities)
        {
            _repository.DeleteRange(Entities);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public void ServiceTest()
        {
            throw new NotImplementedException();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public void Update(T Entity)
        {
            _repository.Update(Entity);
            _unitOfWork.Commit();
        }
    }
}
