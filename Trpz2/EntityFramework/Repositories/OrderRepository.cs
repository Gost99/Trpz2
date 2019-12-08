using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private StoreContext _context;

        public OrderRepository()
        {
            _context = new StoreContext();
        }

        public void Insert(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Update(Order item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
                _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return _context.Orders.Where(predicate);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
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
