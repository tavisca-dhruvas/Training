using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first Amount (Amount Currency) ");
                var amount = new Money(Console.ReadLine());
                Console.WriteLine("Enter the Amount to Convert ");
                string toCurrency = Console.ReadLine();
                var output = amount.ConvertCurrency(toCurrency);
                Console.WriteLine("Your Converted amount is " + output);
                Console.ReadKey();

            }

            catch (Exception e)
            {
                Console.WriteLine("Exception Occured.");
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}