namespace Trpz2.Models
{
    class SpecialOfferDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ProductDto Product { get; set; }
    }
}
