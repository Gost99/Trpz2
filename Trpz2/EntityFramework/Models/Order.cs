using System;
using System.Collections.Generic;

namespace Trpz2.EntityFramework.Models
{
    public class Order
    {
        public long Id { get; set; }

        public Guid Key { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        #region Ctor

        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        #endregion
    }
}
