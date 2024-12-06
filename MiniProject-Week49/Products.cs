using System;
using System.Xml.Linq;
namespace MiniProject_Week49
{
    //Base class for others to inherit
    public class Products
    {

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }

        public Products(string type, string brand, string model, double price, string date)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Price = price;
            Date = date;
        }
    }
}
