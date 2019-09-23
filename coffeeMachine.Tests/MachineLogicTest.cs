using System;
using Xunit;
using Moq;


namespace CoffeeMachine.Tests
{
    public class MachineLogicTest
    {
        [Fact]
        public void SendOrder_Should_Return_Empty_Message()
        {
            // arrange
            var drinkmakerprotocol = new DrinkMakerProtocol();
            var machinelogic = new MachineLogic(drinkmakerprotocol);
            var drinkorder = new Mock<IDrinkOrder>();

            //act 
            string command = machinelogic.sendOrder(drinkorder.Object);

            //assert 
            Assert.Equal(string.Empty ,command);
        }

        [Theory]
        [InlineData(4, 2, "M:2,00")]
        [InlineData(3, 2, "M:1,00")]
        [InlineData(2.50, 2, "M:0,50")]
        public void SendOrder_Should_Return_Message_With_Insufficient_Money_in_Message(double drinkprice, double InsertedAmount, string expectedMessage)
        {
            // arrange
            var drinkorder = new Mock<IDrinkOrder>();
            drinkorder.Setup(x => x.getDrinkPrice()).Returns(drinkprice);

            var drinkMakerProtocol = new DrinkMakerProtocol();
            var machineLogic = new MachineLogic(drinkMakerProtocol);
            machineLogic.InsertMoney(InsertedAmount);

            // act
            string sendededMessage = machineLogic.sendOrder(drinkorder.Object);

            // assert
            Assert.Equal(expectedMessage, sendededMessage);
        }
        

        [Theory]
        [InlineData("test", "M:test")]
        [InlineData("this is an example", "M:this is an example")]
        public void sendMessage_Should_Return_Correct_Instruction_For_Message(string message, string expectedMessage)
        {
            // arrange
            var drinkMakerProtocol = new Mock<IDrinkMakerProtocol>();
            drinkMakerProtocol.Setup(x => x.buildMessage(message)).Returns(expectedMessage);

            var CoffeeMachineLogic = new MachineLogic(drinkMakerProtocol.Object);

            // act
            string forwardedMessage = CoffeeMachineLogic.sendMessage(message);

            // assert
            Assert.Equal(expectedMessage, forwardedMessage);
        }
    }
}
