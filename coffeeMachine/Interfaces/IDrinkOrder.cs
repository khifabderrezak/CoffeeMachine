using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrinkOrder
    {
        string GetDrinkCode();
        int GetDrinkSugarQty();
        double GetDrinkPrice();
        bool GetExtraHot();


    }
}
