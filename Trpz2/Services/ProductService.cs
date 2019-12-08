using AutoMapper;
using System;
using System.Collections.Generic;
using Trpz2.DataContainer.Abstractions;
using Trpz2.EntityFramework.Models;
using Trpz2.EntityFramework.Repositories;
using Trpz2.Models;
using Trpz2.Services.Abstractions;

namespace Trpz2.Services
{
    public class ProductService: IProductService
    {
        IRepository<Product> _db { get; set; }
        IMapper _mapper;


        public ProductService()
        {
            _db = new ProductRepository();

            MapperConfiguration config = new MapperConfiguration(con =>
            {
                con.CreateMap<Product, ProductDto>().ReverseMap();
                con.CreateMap<Tag, TagDto>().ReverseMap();
                con.CreateMap<Order, OrderDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public void Create(ProductDto product)
        {
            if (product == null)
                throw new NullReferenceException("Can not create null object");
            try
            {
                Product newProduct = _mapper.Map<Product>(product);
                _db.Insert(newProduct);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not create an instance of Product", ex);
            }
        }

        public void Update(ProductDto product)
        {
            try
            {
                Product newProduct = _mapper.Map<Product>(product);
                _db.Update(newProduct);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not update an instance of Product", ex);
            }
        }

        public void Delete(int productId)
        {
            try
            {
                _db.Delete(productId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot delete an instance of Product", ex);
            }
        }

        public IEnumerable<ProductDto> GetAll()
        {
            IEnumerable<ProductDto> result;
            try
            {
                IEnumerable<Product> products = _db.GetAll();
                result = _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not get instances of Product", ex);
            }
            return result;
        }

        public ProductDto Get(int productId)
        {
            Product product;
            ProductDto result;
            try
            {
                product = _db.Find(productId);
                result = _mapper.Map<Product, ProductDto>(product);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Can not get instances of Product", ex);
            }
            return result;
        }

    }
}
