using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrinkOrder
    {
        string getDrinkCode();
        int getDrinkSugarQty();
        double getDrinkPrice();
    }
}
