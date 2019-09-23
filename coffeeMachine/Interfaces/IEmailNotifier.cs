using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IEmailNotifier
    {
        void NotifyMissingDrink(String drink);
    }
}
