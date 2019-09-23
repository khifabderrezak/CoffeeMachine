using System;
using Xunit;
using Moq;


namespace CoffeeMachine.Tests
{
    public class MachineLogicTest
    {
        [Fact]
        public void SendCommand_Should_Return_Empty_Message()
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
        [InlineData("test", "M:test")]
        [InlineData("this is an example", "M:this is an example")]
        public void ForwardMessage_Should_Return_Correct_Instruction_For_Message(string message, string expectedMessage)
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
