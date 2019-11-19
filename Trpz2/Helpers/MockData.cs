using System;
using System.Collections.Generic;
using Trpz2.Models;

namespace Trpz2.Helpers
{
    public static class MockData
    {
        public static List<Item> MockItems = new List<Item>
        {
            new Item(){Name = "Burger", Description="Tasty dish", Price=59.99},
            new Item(){Name = "Sushi", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Potato", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Fruits", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Pancake", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Cake", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Soup", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Meat", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Chicken", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Roll", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Bread", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())},
            new Item(){Name = "Rabbit", Description="Tasty dish", Price=GenerateRandomNumber(GenerateRandomNumber())}
        };

        #region random

        private static Random random;
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        private static double GenerateRandomNumber(int max)
        {
            InitRandomNumber(max);
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(max);
            
        }

        private static int GenerateRandomNumber()
        {
            var a = new Random();
            return a.Next();
        }
        #endregion
    }
}
