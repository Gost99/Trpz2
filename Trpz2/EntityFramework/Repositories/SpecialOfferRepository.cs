using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;

namespace Trpz2.EntityFramework.Repositories
{
    public class SpecialOfferRepository : IRepository<SpecialOffer>
    {
        private StoreContext _context;

        public SpecialOfferRepository()
        {
            _context = new StoreContext();
        }

        public void Insert(SpecialOffer item)
        {
            _context.SpecialOffers.Add(item);
            _context.SaveChanges();
        }

        public void Update(SpecialOffer item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            SpecialOffer specialOffer = _context.SpecialOffers.Find(id);
            if (specialOffer != null)
                _context.SpecialOffers.Remove(specialOffer);
            _context.SaveChanges();
        }

        public SpecialOffer Find(int id)
        {
            return _context.SpecialOffers.Find(id);
        }

        public IEnumerable<SpecialOffer> Find(Expression<Func<SpecialOffer, bool>> predicate)
        {
            return _context.SpecialOffers.Where(predicate);
        }

        public IEnumerable<SpecialOffer> GetAll()
        {
            return _context.SpecialOffers.ToList();
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
