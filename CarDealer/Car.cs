using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool InStock { get; set; } // true = в наличии, false = под заказ
        public int Count { get; set; }
        public string Trim { get; set; } // комплектация
        public decimal Price { get; set; }
        public string Discounts { get; set; } // скидки (госпрограммы и т.д.)

        public Car(string brand, string model, int year, bool inStock, int count, string trim, decimal price, string discounts)
        {
            Brand = brand;
            Model = model;
            Year = year;
            InStock = inStock;
            Count = count;
            Trim = trim;
            Price = price;
            Discounts = discounts;
        }

        public override string ToString()
        {
            return $"{Brand} {Model}";
        }
    }
}
