

using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Technical.Domain.Repository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {

        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetEntity(TKey Id);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);

    }

}
