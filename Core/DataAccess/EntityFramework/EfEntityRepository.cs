using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _tContext;

        public EfEntityRepository(TContext tContext)
        {
            _tContext = tContext;
        }

        public async Task Add(TEntity entity)
        {
            var addedEntity = _tContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _tContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            var deletedEntity = _tContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _tContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _tContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? await _tContext.Set<TEntity>().ToListAsync()
                : await _tContext.Set<TEntity>().Where(filter).ToListAsync();

        }

        public List<TEntity> GetAllNoAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _tContext.Set<TEntity>().ToList()
                : _tContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetNoAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _tContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public async Task Update(TEntity entity)
        {
            var updateEntity = _tContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            await _tContext.SaveChangesAsync();
        }
    }
}
