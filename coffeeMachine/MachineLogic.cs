using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        private readonly Cashier cashier;
        readonly IRepository repository;

        public MachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            this.cashier = new Cashier();
            this.repository = new Repository();
        }

        public string SendOrder(IDrinkOrder drinkOrder)
        {
            var drinkprice = drinkOrder.GetDrinkPrice();
            if (!IsPayed(drinkprice))
            {
                return MessageInsufficientAmount(drinkprice);
            }
            this.drinkMakerProtocol.SetCode(drinkOrder.GetDrinkCode());
            this.drinkMakerProtocol.SetSugarQty(drinkOrder.GetDrinkSugarQty());

            this.repository.AddCommand(drinkOrder, DateTime.Now);
            return this.drinkMakerProtocol.MakeOrder();
        }

        public string SendMessage(string message)
        {
            return this.drinkMakerProtocol.BuildMessage(message);
        }

        public string MessageInsufficientAmount(double drinkPrice)
        {

            double missingAmount = this.cashier.GetDifferenceWith(drinkPrice);
            return this.SendMessage(string.Format("{0:0.00}", missingAmount));
        }

        public bool IsPayed(double drinkPrice)
        {
            return this.cashier.GetDifferenceWith(drinkPrice) <= 0;
        }

        public void InsertMoney(double money)
        {
            this.cashier.AddMoney(money);
        }
    }
}
