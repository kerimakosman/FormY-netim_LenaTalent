using Entities.Context;
using Entities.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        private readonly SqlDbContext _db;
        public RepositoryBase(SqlDbContext db)
        {
            _db = db;
        }
        public DbSet<T> Table => _db.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FindAsync(id);
            return Remove(model);
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
         => filter == null
            ? await Table.ToListAsync()
            : await Table.Where(filter).ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await Table.FindAsync(id);


        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null)
        => await Table.Where(filter).FirstOrDefaultAsync();


        public async Task<int> SaveAsync()
        => await _db.SaveChangesAsync();

    }
}
