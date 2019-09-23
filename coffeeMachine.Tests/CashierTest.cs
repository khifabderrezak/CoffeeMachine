using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CashierTest
    {
        

        [Theory]
        [InlineData(2, 1, -1)]
        [InlineData(5, 3, -2)]
        [InlineData(4.45, 4.45, 0)]
        public void GetDifferenceWith_Should_Compute_Difference(double insertedMoney, double price, double difference)
        {
            // arrange 
            var cashier = new Cashier();
            cashier.AddMoney(insertedMoney);

            // act
            double expectedAmount = cashier.GetDifferenceWith(price);
            
            // assert
            Assert.Equal<double>(expectedAmount, difference);
        }
    }
}
