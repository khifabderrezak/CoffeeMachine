using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class HotDrink : Drink, IHotDrink
    {
        public int sugarQty;
        public bool extraHot;


        public int SugarQty
        {
            get
            {
                return this.sugarQty;
            }

        }
        public bool ExtraHot
        {
            get
            {
                return this.extraHot;
            }

            set
            {
                this.extraHot = value;
            }

        }
        public HotDrink(string code, double price) : base(code, price)
        {
        }
        public IHotDrink AddSugar()
        {
            if (this.SugarQty >= 2)
            {
                return this;
            }

            this.sugarQty++;
            return this;
        }
    }
}
