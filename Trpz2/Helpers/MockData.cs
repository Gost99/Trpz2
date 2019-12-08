using System;
using System.Collections.Generic;
using Trpz2.Models;

namespace Trpz2.Helpers
{
    public static class MockData
    {
        public static ICollection<ProductDto> MockItems = new List<ProductDto>
        {
            new ProductDto(){ Id = 0, Name = "Burger", Description="Tasty dish", Price=59.99},
            new ProductDto(){ Id = 1, Name = "Sushi", Description="Tasty dish", Price=16.54},
            new ProductDto(){ Id = 2, Name = "Potato", Description="Tasty dish", Price=11.65},
            new ProductDto(){ Id = 3, Name = "Fruits", Description="Tasty dish", Price=45.42},
            new ProductDto(){ Id = 4, Name = "Pancake", Description="Tasty dish", Price=13.90},
            new ProductDto(){ Id = 5, Name = "Cake", Description="Tasty dish", Price=40.89},
            new ProductDto(){ Id = 6, Name = "Soup", Description="Tasty dish", Price=90.21},
            new ProductDto(){ Id = 7, Name = "Meat", Description="Tasty dish", Price=84.21 },
            new ProductDto(){ Id = 8, Name = "Chicken", Description="Tasty dish", Price=99.12},
            new ProductDto(){ Id = 9, Name = "Roll", Description="Tasty dish", Price=83.21},
            new ProductDto(){ Id = 10, Name = "Bread", Description="Tasty dish", Price=34.12},
            new ProductDto(){ Id = 11, Name = "Rabbit", Description="Tasty dish", Price=36.94}
        };
    }
}
