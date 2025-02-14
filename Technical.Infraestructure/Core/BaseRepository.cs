

using Technical.Domain.Repository;
using Technical.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Technical.Infraestructure.Core
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ProductsContext context;
        private DbSet<TEntity> entities;

        public BaseRepository(ProductsContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public TEntity GetEntity(TKey Id)
        {
            return this.entities.Find(Id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}
