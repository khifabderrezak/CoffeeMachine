using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class DrinkOrder: IDrinkOrder
    {
        private readonly IDrink drink;
        public DrinkOrder(IDrink drink)
        {
            this.drink = drink;
        }
        public string GetDrinkCode()
        {
            return this.drink.Code;
        }
        public int GetDrinkSugarQty()
        {

            if(drink is IHotDrink)
            {
                return ((IHotDrink)drink).SugarQty;
            }
            return 0;
        }

        public double GetDrinkPrice()
        {
            return this.drink.Price;
        }
           
        public bool GetExtraHot()
        {
            if (drink is IHotDrink)
            {
                return ((IHotDrink)drink).ExtraHot;
            }
            return false;
        }

    }
}
