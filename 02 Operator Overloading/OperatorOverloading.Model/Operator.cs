using System;
using OperatorOverloading.Dbl;
using System.Text.RegularExpressions;
namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;

        public double Amount
        {
            get { return _amount; }
            private set
            {

                if (double.IsPositiveInfinity(value) || value > double.MaxValue || value < 0)
                {
                    throw new Exception(Resources.InvalidAmount);
                }
                _amount = value;
            }
        }

        public string Currency
        {
            get { return _currency; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(Resources.InvalidCurrency);
                }
                _currency = value;
            }
        }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputAmount">eg 100 USD</param>
        public Money(string inputAmount)
        {

            if (string.IsNullOrWhiteSpace(inputAmount))
            {
                throw new Exception(Resources.InvalidAmount);
            }

            var amountArr = inputAmount.Split(' ');
            double amount;

            if (amountArr.Length != 2)
            {
                throw new Exception(Resources.InvalidAmount);
            }

            if (double.TryParse(amountArr[0], out amount) == false)
            {
                throw new Exception(Resources.InvalidAmount);
            }
            Amount = amount;
            Currency = amountArr[1];
        }
        /// <summary>
        /// Converts the Money into desired Currency 
        /// </summary>
        /// <param name="INR"></param>
        /// <returns>100 INR</returns>
        public Money ConvertCurrency(string toCurrency)
        {
            if (string.IsNullOrWhiteSpace(toCurrency) || toCurrency.Length != 3 || Regex.IsMatch(toCurrency, @"^[a-zA-Z]+$") == false)
            {
                throw new System.Exception(Resources.InvalidCurrency);
            }
            CurrencyConverter currencyObject = new CurrencyConverter();
            var exchangeRate = currencyObject.GetConversion(this.Currency, toCurrency);
            Amount = exchangeRate * this.Amount;
            if (double.IsPositiveInfinity(Amount) || Amount > double.MaxValue)
            {
                throw new System.Exception(Resources.InvalidSum);

            }
            Money Money2 = new Money(Amount, toCurrency);
            return (Money2);
        }



        public static Money operator +(Money object1, Money object2)
        {
            if (object1 == null || object2 == null)
            {
                throw new Exception(Resources.InvalidObject);
            }
            if (!object1.Currency.Equals(object2.Currency, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception(Resources.InvalidCurrency);
            }
            else
            {
                var totalAmount = object1.Amount + object2.Amount;
                return new Money(totalAmount, object1.Currency);
            }

        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}