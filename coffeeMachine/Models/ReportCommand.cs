using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
   
    public class ReportCommand
    {
        public IDrinkOrder Order { get; private set; }
        public DateTime OrderTime { get; private set; }

        public ReportCommand(IDrinkOrder order, DateTime orderTime)
        {
            Order = order;
            OrderTime = orderTime;
        }
    }
}
