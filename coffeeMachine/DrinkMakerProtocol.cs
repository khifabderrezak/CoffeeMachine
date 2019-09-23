using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol : IDrinkMakerProtocol
    {
        private string code;
        private int sugarQty;
        private bool extraHot = false;

        public string BuildMessage(string message)
        {
            return string.Format("M:{0}", message); 
        }

        public string MakeOrder()
        {
            if(this.code == null)
            {
                return string.Empty;
            }
            var hot = "";
            if (extraHot)
            {
                hot = "h";
            }
            if (this.sugarQty > 0)
            {
                
                return string.Format("{0}{1}:{2}:1", this.code, hot, this.sugarQty);
            }
            return string.Format("{0}{1}::", this.code, hot);
        }

        public void SetCode(string code)
        {
            this.code = code;
        }

        public void SetSugarQty(int sugarQty)
        {
            this.sugarQty = sugarQty;
        }
        public void SetExtraHot(bool extraHot)
        {
            this.extraHot = extraHot;
        }
    }
}
