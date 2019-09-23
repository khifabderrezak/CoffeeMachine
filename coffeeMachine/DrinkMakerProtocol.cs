using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol : IDrinkMakerProtocol
    {
        private string code;
        private int sugarQty;


        public string buildMessage(string message)
        {
            return string.Format("M:{0}", message); 
        }

        public string makeOrder()
        {
            if(this.code == null)
            {
                return string.Empty;
            }
            if(this.sugarQty > 0)
            {
                return string.Format("{0}:{1}:1", this.code, this.sugarQty);
            }
            return string.Format("{0}::", this.code);
        }

        public void setCode(string code)
        {
            this.code = code;
        }

        public void setSugarQty(int sugarQty)
        {
            this.sugarQty = sugarQty;
        }
    }
}
