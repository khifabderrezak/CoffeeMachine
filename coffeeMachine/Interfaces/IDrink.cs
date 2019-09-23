using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrink
    {
        string Code { get; }
        double Price { get; }
        
    }
}
