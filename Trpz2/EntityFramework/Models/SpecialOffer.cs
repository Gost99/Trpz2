namespace Trpz2.EntityFramework.Models
{
    public class SpecialOffer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
