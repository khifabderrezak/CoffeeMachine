using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class MachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        private readonly Cashier cashier;
        private readonly IRepository repository;
        private readonly IBeverageQuantityChecker beverageQuantityChecker;
        private readonly IEmailNotifier emailNotifier;

        public MachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            this.cashier = new Cashier();
            this.repository = new Repository();

        }

        public MachineLogic(IDrinkMakerProtocol drinkMakerProtocol, 
            IBeverageQuantityChecker beverageQuantityChecker, 
            IEmailNotifier emailNotifier)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            this.cashier = new Cashier();
            this.repository = new Repository();
            this.beverageQuantityChecker = beverageQuantityChecker;
            this.emailNotifier = emailNotifier;
        }


        private bool IsThereShortage(string drink)
        {
            if (this.beverageQuantityChecker.IsEmpty(drink))
            {
                this.emailNotifier.NotifyMissingDrink(drink);
                return true;
            }
            return false;
        }

        public string SendOrder(IDrinkOrder drinkOrder)
        {
            string code = drinkOrder.GetDrinkCode();
            double drinkprice = drinkOrder.GetDrinkPrice();
            if (!IsPayed(drinkprice))
            {
                return MessageInsufficientAmount(drinkprice);
            }
            this.drinkMakerProtocol.SetCode(code);
            this.drinkMakerProtocol.SetSugarQty(drinkOrder.GetDrinkSugarQty());

            if (this.IsThereShortage(code))
            {
                return this.SendMessage(string.Format("there's a shortage with {0}",code));
            }

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
