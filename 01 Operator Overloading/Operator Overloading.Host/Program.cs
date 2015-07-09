using System;
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
                var amount1 = new Money(Console.ReadLine());

                Console.Write("Enter second  Amount (Amount Currency) ");
                var amount2 = new Money(Console.ReadLine());

                Console.Write(amount1 + amount2+" is the Total Amount  ");
                
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