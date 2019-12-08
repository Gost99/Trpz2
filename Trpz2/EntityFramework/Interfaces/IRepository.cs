using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trpz2.DataContainer.Abstractions
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity item);

        void Update(TEntity item);

        void Delete(int id);

        TEntity Find(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
    }
}
