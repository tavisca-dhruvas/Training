using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set 
            {
                if (value < 0 && value > double.MaxValue)
                {
                    throw new System.Exception(Resource.InvalidValue);
                }
                this._amount=value;
            }
        }
        private string _currency;
        public string currency
        {
            get
            {
                return _currency;
            }
            set 
            {
                if (string.IsNullOrEmpty(currency))
                {

                    throw new ArgumentNullException(Resource.InvalidCurrency);
                }
                else
                {
                    this._currency = value;
                    

                }
                
            }
        }
 

        public static Money operator +(Money firstMoneyObject, Money secondMoneyObject)
        {
            var thirdMoneyObject = new Money();
            if (firstMoneyObject.currency.Equals(secondMoneyObject.currency,StringComparison.InvariantCultureIgnoreCase))
            {
                    thirdMoneyObject.Amount = firstMoneyObject.Amount + secondMoneyObject.Amount;
                    thirdMoneyObject.currency = firstMoneyObject.currency;
                    if (thirdMoneyObject.Amount > double.MaxValue)
                    {
                        throw new ArgumentException(Resource.InvalidSum);
                    }
                    
            }
            else
            {
                throw new System.Exception(Resource.InvalidCurrency);
            }
            return thirdMoneyObject;
            
        }
    }
}
