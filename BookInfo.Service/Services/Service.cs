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
            if (Entity == null)
            {
                throw new Exception("Entity is null!");
            }
            try
            {
                await _repository.AddAsync(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"There is an error. Message: {ex.Message}");
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            if (Entities == null)
            {
                throw new Exception("Entity is null!");
            }
            try
            {
                await _repository.AddRangeAsync(Entities);
            }
            catch (Exception ex)
            {
                throw new Exception($"There is an error. Message: {ex.Message}");
            }
            await _unitOfWork.CommitAsync();
        }

        public void Delete(T Entity)
        {
            if (Entity == null)
            {
                throw new Exception("Entity is null!");
            }
            try
            {
                _repository.Delete(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when object delete. Error Message: {ex.Message}");
            }
            _unitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<T> Entities)
        {
            if (Entities == null)
            {
                throw new Exception("Entity is null!");
            }
            try
            {
                _repository.DeleteRange(Entities);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when object delete. Error Message: {ex.Message}");
            }
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Message: {ex.Message}");
            }
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            try
            {
                return await _repository.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Message: {ex.Message}");
            }
        }

        public void ServiceTest()
        {
            throw new NotImplementedException();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _repository.SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Message: {ex.Message}");
            }
        }

        public void Update(T Entity)
        {
            if (Entity == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                _repository.Update(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Message: {ex.Message}");
            }
            _unitOfWork.Commit();
        }
    }
}
