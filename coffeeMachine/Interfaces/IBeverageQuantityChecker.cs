using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IBeverageQuantityChecker
    {
        bool IsEmpty(String drink);
    }
}
