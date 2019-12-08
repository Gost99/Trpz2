using System;
using System.Collections.Generic;

namespace Trpz2.Models
{
    public class OrderDto
    {
        public long Id { get; set; }

        public Guid Key { get; set; }

        public string Description { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
