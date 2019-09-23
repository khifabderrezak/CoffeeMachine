using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        private readonly Cashier cashier;

        public MachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            cashier = new Cashier();
        }

        public string sendOrder(IDrinkOrder drinkOrder)
        {
            var drinkprice = drinkOrder.getDrinkPrice();
            if (!IsPayed(drinkprice))
            {
                return MessageInsufficientAmount(drinkprice);
            }
            this.drinkMakerProtocol.setCode(drinkOrder.getDrinkCode());
            this.drinkMakerProtocol.setSugarQty(drinkOrder.getDrinkSugarQty());

            return this.drinkMakerProtocol.makeOrder();
        }

        public string sendMessage(string message)
        {
            return this.drinkMakerProtocol.buildMessage(message);
        }

        public string MessageInsufficientAmount(double drinkPrice)
        {

            double missingAmount = this.cashier.getDifferenceWith(drinkPrice);
            return this.sendMessage(string.Format("{0:0.00}", missingAmount));
        }

        public bool IsPayed(double drinkPrice)
        {
            return this.cashier.getDifferenceWith(drinkPrice) <= 0;
        }

        public void InsertMoney(double money)
        {
            this.cashier.AddMoney(money);
        }
    }
}
