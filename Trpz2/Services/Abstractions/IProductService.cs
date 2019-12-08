using System.Collections.Generic;
using Trpz2.Models;

namespace Trpz2.Services.Abstractions
{
    public interface IProductService
    {
        void Create(ProductDto product);
        void Update(ProductDto product);
        void Delete(int productId);
        ProductDto Get(int productId);

        IEnumerable<ProductDto> GetAll();
    }
}
