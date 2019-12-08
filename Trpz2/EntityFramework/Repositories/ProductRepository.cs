using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext _context;

        public ProductRepository()
        {
            _context = new StoreContext();
        }

        public void Insert(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            Product _product = Find((int)item.Id);
            if (_product != null)
                _context.Entry(_product).CurrentValues.SetValues(item);
            //_context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
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
