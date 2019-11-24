using System.Collections.Generic;

namespace Trpz2.DataContainer.Abstractions
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);

        void Update(long id, TEntity entity);

        void Delete(long id);

        TEntity Get(long id);

        IEnumerable<TEntity> GetAll();
    }
}
