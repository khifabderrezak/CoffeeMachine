using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Cashier
    {
        private double InsertedAmount = 0;

        public void AddMoney(double money)
        {
            InsertedAmount += money;
        }
        
        public double getDifferenceWith(double price)
        {
            return price - InsertedAmount;
        }
    }
}
