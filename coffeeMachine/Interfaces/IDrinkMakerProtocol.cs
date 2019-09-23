using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IDrinkMakerProtocol
    {

        void SetSugarQty(int sugarQty);
        void SetCode(string code);
        void SetExtraHot(bool ExtraHot);
        string MakeOrder();
        string BuildMessage(string message);
    }
}
