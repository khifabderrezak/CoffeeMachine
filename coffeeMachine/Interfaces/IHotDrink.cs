using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IHotDrink : IDrink
    {
        IHotDrink AddSugar();
        bool ExtraHot { get; set; }
        int SugarQty { get; }

    }
}
