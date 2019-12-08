using System.Collections.Generic;

namespace Trpz2.EntityFramework.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public long? TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        #region Ctors

        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        #endregion
    }
}
