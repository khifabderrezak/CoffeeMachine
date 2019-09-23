using System;
using Xunit;


namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTest
    {
        [Fact]
        public void BuildCommand_Should_Build_Empty_Message()
        {
            // arange
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // act
            string message = drinkMakerProtocol.makeOrder();

            // assert
            Assert.Empty(message);
        }

        [Theory]
        [InlineData("test", "M:test")]
        public void BuildMessage_Should_Build_Message(string message_content, string expectedMessage)
        {
            // arange
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // act
            string message = drinkMakerProtocol.buildMessage(message_content);

            // assert
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData("C", "C::")]
        [InlineData("H", "H::")]
        [InlineData("T", "T::")]
        public void BuildMessage_Sould_Build_Message_Just_Drink(string drinkCode, string expectedMessage)
        {
            // arange
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            drinkMakerProtocol.setCode(drinkCode);

            // act
            string message = drinkMakerProtocol.makeOrder();

            // assert
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData("C", 0, "C::")]
        [InlineData("H", 1,"H:1:1")]
        [InlineData("T", 3,"T:3:1")]
        public void BuildMessage_Sould_Build_Message_For_Drink_And_Sugar(string drinkCode, int sugarQty ,string expectedMessage)
        {
            // arange
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            drinkMakerProtocol.setCode(drinkCode);
            drinkMakerProtocol.setSugarQty(sugarQty);

            // act
            string message = drinkMakerProtocol.makeOrder();

            // assert
            Assert.Equal(expectedMessage, message);
        }
    }
}
