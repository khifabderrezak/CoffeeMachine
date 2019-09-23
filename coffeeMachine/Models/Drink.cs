using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public abstract class Drink : IDrink
    {
        private string code;
        private int sugarQty;
        private double price;

        public string Code
        {
            get
            {
                return this.code;
            }
        }
        public int SugarQty
        {
            get
            {
                return this.sugarQty;
            }
            
        }

        public double Price
        {
            get
            {
                return this.price;
            }

        }

        protected Drink(string code, double price)
        {
            this.code = code;
            this.price = price;
        }

        public IDrink AddSugar()
        {
            if(this.SugarQty == 2)
            {
                return this;
            }

            this.sugarQty++;
            return this;
        }
    }
}
