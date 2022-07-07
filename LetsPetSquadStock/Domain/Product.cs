using Stock.Domain.Common;
using Stock.Domain;
using System;
using System.Collections.Generic;

namespace Stock.Domain
{
    public class Product
    {
        public Category Category { get; private set; }
        public Usage Usage { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public decimal Price { get; private set; }
        public int TotalVolume { get; private set; }
        public int CurrentVolume { get; set; }
        public DateTime ExpirationDate { get; private set; }
        public Species Species { get; private set; }

        public Product()
        {
        }

        public Product(Category category, Usage usage, string name, string brand, decimal price,
            int totalVolume, DateTime expirationDate, Species species)
        {
            Category = category;
            Usage = usage;
            Name = name;
            Brand = brand;
            Price = price;
            TotalVolume = totalVolume;
            CurrentVolume = totalVolume;
            ExpirationDate = expirationDate;
            Species = species;
        }

        public void spendProduct(int toExpendVolume)
        {
            CurrentVolume -= toExpendVolume;
        }
    }

}
