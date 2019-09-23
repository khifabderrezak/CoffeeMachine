using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrinkMakerProtocol
    {

        void setSugarQty(int sugarQty);
        void setCode(string code);
        string makeOrder();
        string buildMessage(string message);
    }
}
