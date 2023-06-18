using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        T GetNoAsync(Expression<Func<T,bool>> filter);
        List<T> GetAllNoAsync(Expression<Func<T,bool>> filter = null);
        void UpdateNotAsync(T entity);
    }
}
