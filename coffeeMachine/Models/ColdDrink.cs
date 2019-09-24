using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class ColdDrink : Drink, IColdDrink
    {
        public ColdDrink(string code, double price) : base(code, price)
        {
        }
    }
}
