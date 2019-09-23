using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class DrinkOrder
    {
        private IDrink drink;
        public DrinkOrder(IDrink drink)
        {
            this.drink = drink;
        }
        public string getDrinkCode()
        {
            return this.drink.Code;
        }
        public int getDrinkSugarQty()
        {
            return this.drink.SugarQty;
        }
    }
}
