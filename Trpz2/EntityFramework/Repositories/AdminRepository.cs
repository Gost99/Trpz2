using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework.Repositories
{
    public class AdminRepository : IRepository<Administrator>
    {
        private StoreContext _context;

        public AdminRepository()
        {
            _context = new StoreContext();
        }

        public void Insert(Administrator item)
        {
            _context.Administrators.Add(item);
            _context.SaveChanges();
        }

        public void Update(Administrator item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Administrator administrator = _context.Administrators.Find(id);
            if (administrator != null)
                _context.Administrators.Remove(administrator);
            _context.SaveChanges();
        }

        public Administrator Find(int id)
        {
            return _context.Administrators.Find(id);
        }

        public IEnumerable<Administrator> Find(Expression<Func<Administrator, bool>> predicate)
        {
            return _context.Administrators.Where(predicate);
        }

        public IEnumerable<Administrator> GetAll()
        {
            return _context.Administrators.ToList();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
