using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class Repository : IRepository
    {
        readonly List<ReportCommand> orderData;
        public Repository()
        {
            this.orderData = new List<ReportCommand>();
        }
        public void AddCommand(IDrinkOrder order, DateTime orderTime)
        {
            this.orderData.Add(new ReportCommand(order, orderTime));
        }

        public List<ReportCommand> GetReport()
        {
            return orderData;
        }
    }
}
