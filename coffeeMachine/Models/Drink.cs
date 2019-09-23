using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public abstract class Drink : IDrink
    {
        private string code;
        private int sugarQty;
        

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

        public Drink(string code)
        {
            this.code = code ;
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
