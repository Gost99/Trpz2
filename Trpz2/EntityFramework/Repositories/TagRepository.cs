using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private StoreContext _context;

        public TagRepository()
        {
            _context = new StoreContext();
        }

        public void Insert(Tag item)
        {
            _context.Tags.Add(item);
            _context.SaveChanges();
        }

        public void Update(Tag item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tag tag = _context.Tags.Find(id);
            if (tag != null)
                _context.Tags.Remove(tag);
            _context.SaveChanges();
        }

        public Tag Find(int id)
        {
            return _context.Tags.Find(id);
        }

        public IEnumerable<Tag> Find(Expression<Func<Tag, bool>> predicate)
        {
            return _context.Tags.Where(predicate);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.ToList();
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
