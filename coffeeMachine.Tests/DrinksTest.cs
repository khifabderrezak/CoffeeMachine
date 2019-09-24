using System;
using Xunit;


namespace CoffeeMachine.Tests
{
    public class DrinksTest
    {
        [Fact]
        public void AddSugar_Should_Add_Sugar_To_Drink()
        {
            // arange
            HotDrink drink = new Coffee();
            int expectedSugarQty= 1;

            // act
            drink.AddSugar();
            

            // assert
            Assert.Equal(expectedSugarQty, drink.SugarQty);
             
        }

        [Fact]
        public void AddSugar_Should_Add_two_Sugar_To_Drink()
        {
            // arange
            HotDrink drink = new Coffee();
            int expectedSugarQty = 2;

            // act
            drink.AddSugar().AddSugar();


            // assert
            Assert.Equal(expectedSugarQty, drink.SugarQty);

        }
        [Fact]
        public void AddSugar_Should_not_Add_more_than_two_Sugar_To_Drink()
        {
            // arange
            HotDrink drink = new Coffee();
            int expectedSugarQty = 2;

            // act
            drink.AddSugar().AddSugar().AddSugar();


            // assert
            Assert.Equal(expectedSugarQty, drink.SugarQty);

        }

    }
}
