using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrink
    {
        string Code { get; }
        int SugarQty { get; }
        double Price { get; }
        IDrink AddSugar();
    }
}
