using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    
    public interface IRepository
    {
        void AddCommand(IDrinkOrder order, DateTime orderTime);

        List<ReportCommand> GetReport();
    }
    
}
