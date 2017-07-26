using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EShuiPlat.DBHelper.Interfaces
{
    public interface IRepository<TEntity>
          where TEntity : class, IAggregateRoot
    {
        void Add(TEntity aggregateRoot);

        void Update(TEntity aggregateRoot);

        void Del(TEntity aggregateRoot);

        TEntity Get(long id);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);
        bool Contains(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(params object[] keys);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity t);
 
        int Delete(Expression<Func<TEntity, bool>> predicate);
     
        TEntity Single(Expression<Func<TEntity, bool>> expression);
    }
}
