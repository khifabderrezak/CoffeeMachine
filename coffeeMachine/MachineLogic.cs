using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        public MachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
        }

        public string sendOrder(IDrinkOrder drinkOrder)
        {
            this.drinkMakerProtocol.setCode(drinkOrder.getDrinkCode());
            this.drinkMakerProtocol.setSugarQty(drinkOrder.getDrinkSugarQty());

            return this.drinkMakerProtocol.makeOrder();
        }

        public string sendMessage(string message)
        {
            return this.drinkMakerProtocol.buildMessage(message);
        }
    }
}
