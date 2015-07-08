using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var firstMoneyObject = new Money();
                var secondMoneyObject = new Money();
                firstMoneyObject = Initialize(firstMoneyObject);
                secondMoneyObject = Initialize(secondMoneyObject);
                Money resultMoneyObject = firstMoneyObject + secondMoneyObject;
                Console.WriteLine(resultMoneyObject.Amount + resultMoneyObject.currency);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static Money Initialize(Money moneyObject) 
        {
            Console.WriteLine("Enter the Amount");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Current");
            string currency = Console.ReadLine();
                moneyObject.Amount = amount;
                moneyObject.currency = currency;
                return moneyObject;
        }
    }
}
