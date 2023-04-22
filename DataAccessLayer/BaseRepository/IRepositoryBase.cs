using Entities.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseRepository
{
    public interface IRepositoryBase<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool Update(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<int> SaveAsync();
    }
}
