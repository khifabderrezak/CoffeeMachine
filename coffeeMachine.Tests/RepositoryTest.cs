using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class RepositoryTest
    {
        

        [Fact]
        public void AddCommand_should_Add_Order_ToReport()
        {
            // arrange 
            IRepository repo = new Repository();
            IDrink coffee = new Coffee();
            IDrinkOrder drinkOrder = new DrinkOrder(coffee);

            // act
            repo.AddCommand(drinkOrder, DateTime.Now);
            var  Report = repo.GetReport();
            
            // assert
            Assert.NotEmpty(Report);
        }

        [Theory]
        [InlineData(2)]
        public void AddCommand_should_Have_All_OrderDrink(int expectedLength)
        {
            // arrange 
            IRepository repo = new Repository();
            IDrink coffee = new Coffee();
            IDrinkOrder drinkOrder1 = new DrinkOrder(coffee);
            IDrink Orange = new Coffee();
            IDrinkOrder drinkOrder2 = new DrinkOrder(coffee);

            // act
            repo.AddCommand(drinkOrder1, DateTime.Now);
            repo.AddCommand(drinkOrder2, DateTime.Now);
            var Report = repo.GetReport();

            // assert
            Assert.Equal(expectedLength, Report.Count);
        }
    }
}
