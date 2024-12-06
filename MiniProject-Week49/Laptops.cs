using System;

namespace MiniProject_Week49
{
    //Derived class that inherits from class Products
    public class Laptop : Products
	{
        public Laptop(string type, string brand, string model, double price, string date) : base(type, brand, model, price, date)
        { 

        }
    }
}