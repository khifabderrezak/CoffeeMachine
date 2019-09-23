using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public abstract class Drink : IDrink
    {
        private readonly string code;
        private readonly double price;
        

        public string Code
        {
            get
            {
                return this.code;
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
        }

        public Drink(string code)
        {
            this.code = code ;
        }

        public Drink(string code, double price)
        {
            this.code = code;
            this.price = price;
        }


    }
}
