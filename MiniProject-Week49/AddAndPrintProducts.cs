using System;
using System.Globalization;

namespace MiniProject_Week49
{
    public class AddAndPrintProducts
    {

        //Create a list for products
        List<Products> products = new List<Products>();

        //Method for checking user input and adding products
        public void AddProduct()
        {

            //Variables used later to check the user input for purchase date
            var dateFormat = "dd/MM/yyyy";
            bool validDate;
            DateTime scheduleDate;

            while (true)
            {

                //Check if user want to add an computer or phone, if user input is invalid loop for correct input
                Console.WriteLine("");
                Console.Write("Choose a product type. Enter 'C' for computer, 'P' for phone or 'E' to exit: ");
                string type = Console.ReadLine().ToLower();
                while (String.IsNullOrEmpty(type) || type != "c" && type != "p" && type != "e")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input for type, please try again.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    type = Console.ReadLine().ToLower();
                }

                //If user enters "e" then break out of while-loop and quit program
                if (type == "e")
                {
                    break;
                }

                //Check user input for brand, if user input is empty loop for correct input
                Console.Write("Enter the product brand: ");
                string brand = Console.ReadLine();
                while (String.IsNullOrEmpty(brand))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input for brand, please try again.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    brand = Console.ReadLine();
                }

                //Check user input for model, if user input is empty loop for correct input
                Console.Write("Enter the product model: ");
                string model = Console.ReadLine();
                while (String.IsNullOrEmpty(model))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input for model, please try again.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    model = Console.ReadLine();
                }

                //Check user input for price, if user input is invalid loop for correct input
                Console.Write("Enter the products price (in numbers): ");
                bool number = double.TryParse(Console.ReadLine(), out double price);
                while (number == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input for price, please try again.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    number = double.TryParse(Console.ReadLine(), out double priceTwo);
                    price = priceTwo;
                }

                /*Check user input for date and then use DateTime.TryParseExact and "dateTime" to see if user input is in correct format,
                if TryParseExact returns false to bool "validDate" then loop for correct user input*/
                Console.Write("Enter date of purchase (MM/DD/YYYY): ");
                string date = Console.ReadLine();
                validDate = DateTime.TryParseExact(date,dateFormat,DateTimeFormatInfo.InvariantInfo,DateTimeStyles.None,out scheduleDate);
                while(validDate == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong input or format on date, please try again.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    date = Console.ReadLine();
                    validDate = DateTime.TryParseExact(date, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None,out scheduleDate);
                }

                //Check if the product type entered before is computer or phone
                if (type == "c") //If computer add it as laptop to the list and tell the user everything went OK
                {
                    type = "Computer";
                    products.Add(new Laptop(type, brand, model, price, date));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("The product was succesfully added to the database!");
                    Console.WriteLine("");
                    Console.ResetColor();
                }
                else if (type == "p") //If phone add it as mobilephone to the list and tell the user everything went OK
                {
                    type = "Phone";
                    products.Add(new MobilePhone(type, brand, model, price, date));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("The product was succesfully added to the database!");
                    Console.WriteLine("");
                    Console.ResetColor();
                }

            }

            //After break from While-loop call method Printproducts to print list
            PrintProducts();
            Console.ResetColor();

        }

        //Method for printing all products
        public void PrintProducts()
        {
            //Order list first after product type and then after purchase date
            products = products.OrderBy(product => product.GetType().Name).ThenBy(product => DateTime.Parse(product.Date)).ToList();

            //Write the headers for the list
            Console.WriteLine("");
            Console.WriteLine("Type".PadRight(20) + "Brand".PadRight(20) + "Model".PadRight(20) + "Price".PadRight(20) + "Purchase Date".PadRight(20));
            Console.WriteLine("----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "-----".PadRight(20) + "-------------".PadRight(20));

            //Circle through products and write them on screen, if purchase date is older than 33 months use red text for product 
            foreach (var p in products)
            {
                var time = DateTime.Parse(p.Date);
                if (DateTime.Now.Subtract(time).TotalDays > 1004)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(p.Type.PadRight(20) + p.Brand.PadRight(20) + p.Model.PadRight(20) + p.Price.ToString().PadRight(20) + p.Date.PadRight(20));
            }
        }
    }
}
