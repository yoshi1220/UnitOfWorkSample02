using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Entities
{
    /// <summary>
    /// Repositoryインターフェイス
    /// </summary>
    /// <typeparam name="TEntity">モデルを指定する</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
