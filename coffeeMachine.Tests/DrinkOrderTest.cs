using System;
using Xunit;
using Moq;

namespace CoffeeMachine.Tests
{
    public class DrinkOrderTest
    {
        [Theory]
        [InlineData("C")]
        [InlineData("H")]
        [InlineData("T")]
        public void GetDrinkCode_Should_Return_Code_From_Drink(string expectedDrinkCode)
        {
            // arange 
            var drink = new Mock<IDrink>();
            drink.SetupGet(x => x.Code).Returns(expectedDrinkCode);

            // act
            var DrinkOrder = new DrinkOrder(drink.Object);

            // assert
            Assert.Equal(expectedDrinkCode, DrinkOrder.getDrinkCode());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetDrinkCode_Should_Return_Sugar_Qty_From_Drink(int expectedSugarQty)
        {
            // arange 
            var drink = new Mock<IDrink>();
            drink.Setup(x => x.SugarQty).Returns(expectedSugarQty);

            // act
            var DrinkOrder = new DrinkOrder(drink.Object);

            // assert
            Assert.Equal(expectedSugarQty, DrinkOrder.getDrinkSugarQty());
        }


    }



}
