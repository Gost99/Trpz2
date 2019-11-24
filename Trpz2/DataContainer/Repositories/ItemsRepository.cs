using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trpz2.DataContainer.Abstractions;
using Trpz2.Helpers;
using Trpz2.Models;

namespace Trpz2.DataContainer.Repositories
{
    public class ItemsRepository : IRepository<Item>
    {
        private readonly ICollection<Item> _container;

        public ItemsRepository(ICollection<Item> collection)
        {
            _container = collection;
        }

        public void Delete(long id)
        {
            Item userToDelete = Get(id);
            _container.Remove(userToDelete);
        }

        public Item Get(long id)
        {
            return _container.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _container;
        }

        public void Insert(Item entity)
        {
            long idAfterInsert = _container.Count + 1;
            entity.Id = idAfterInsert;
            _container.Add(entity);
        }

        public void Update(long id, Item entity)
        {
            Delete(id);
            Insert(entity);
        }
    }
}
