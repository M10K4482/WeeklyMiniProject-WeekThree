using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Reflection;

namespace MiniProject_Week49
{
    public class Program
    {
        
        //Main method with object of class AddAndPrintProducts to start the program
        static void Main(string[] args)
        {

            AddAndPrintProducts startProgram = new AddAndPrintProducts();
            startProgram.AddProduct();

        }

    }
}
