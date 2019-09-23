using System;
using Xunit;
using Moq;


namespace CoffeeMachine.Tests
{
    public class MachineLogicTest
    {
        [Theory]
        [InlineData("C")]
        [InlineData("T")]
        [InlineData("H")]
        [InlineData("O")]
        public void SendOrder_Should_Return_Empty_Message(string codeDrink)
        {
            // arrange
            var beverageQuantityChecker = new Mock<IBeverageQuantityChecker>();
            beverageQuantityChecker.Setup(x => x.IsEmpty(codeDrink)).Returns(false);
            var emailNotifier = new Mock<IEmailNotifier>();
            emailNotifier.Setup(x => x.NotifyMissingDrink(codeDrink));
            var drinkmakerprotocol = new DrinkMakerProtocol();
            var machinelogic = new MachineLogic(drinkmakerprotocol, beverageQuantityChecker.Object, emailNotifier.Object);
            var drinkorder = new Mock<IDrinkOrder>();

            //act 
            string command = machinelogic.SendOrder(drinkorder.Object);

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
            drinkorder.Setup(x => x.GetDrinkPrice()).Returns(drinkprice);

            var drinkMakerProtocol = new DrinkMakerProtocol();
            var machineLogic = new MachineLogic(drinkMakerProtocol);
            machineLogic.InsertMoney(InsertedAmount);

            // act
            string sendededMessage = machineLogic.SendOrder(drinkorder.Object);

            // assert
            Assert.Equal(expectedMessage, sendededMessage);
        }
        

        [Theory]
        [InlineData("test", "M:test")]
        [InlineData("this is an example", "M:this is an example")]
        public void SendMessage_Should_Return_Correct_Instruction_For_Message(string message, string expectedMessage)
        {
            // arrange
            var drinkMakerProtocol = new Mock<IDrinkMakerProtocol>();
            drinkMakerProtocol.Setup(x => x.BuildMessage(message)).Returns(expectedMessage);

            var CoffeeMachineLogic = new MachineLogic(drinkMakerProtocol.Object);

            // act
            string forwardedMessage = CoffeeMachineLogic.SendMessage(message);

            // assert
            Assert.Equal(expectedMessage, forwardedMessage);
        }

        [Theory]
        [InlineData("O","O::")]
        public void sendOrder_Sould_Build_Message_For_Orange(string codeDrink, string expectedMessage)
        {
            // arrange
            var beverageQuantityChecker = new Mock<IBeverageQuantityChecker>();
            beverageQuantityChecker.Setup(x => x.IsEmpty(codeDrink)).Returns(false);
            var emailNotifier = new Mock<IEmailNotifier>();
            emailNotifier.Setup(x => x.NotifyMissingDrink(codeDrink));
            var drink = new OrangeJuice();
            var drinkOrder = new DrinkOrder(drink);
            var drinkMakerProtocol = new DrinkMakerProtocol();
            var logicMachine = new MachineLogic(drinkMakerProtocol, beverageQuantityChecker.Object, emailNotifier.Object);
            logicMachine.InsertMoney(.60);


            // act
            string message = logicMachine.SendOrder(drinkOrder);

            // assert
            Assert.Equal(expectedMessage, message);
        }


        [Theory]
        [InlineData("C", .60, "M:there's a shortage with C")]
        [InlineData("T", .40, "M:there's a shortage with T")]
        [InlineData("H", .50, "M:there's a shortage with H")]
        [InlineData("O", .60, "M:there's a shortage with O")]
        public void SendOrder_Should_Return_Message_If_There_Shortage(string codeDrink, double drinkprice, string expectedMessage)
        {
            // arrange
            var beverageQuantityChecker = new Mock<IBeverageQuantityChecker>();
            beverageQuantityChecker.Setup(x => x.IsEmpty(codeDrink)).Returns(true);
            var emailNotifier = new Mock<IEmailNotifier>();
            emailNotifier.Setup(x => x.NotifyMissingDrink(codeDrink));
            var drinkorder = new Mock<IDrinkOrder>();
            drinkorder.Setup(x => x.GetDrinkCode()).Returns(codeDrink);
            var drinkMakerProtocol = new DrinkMakerProtocol();
            var machineLogic = new MachineLogic(drinkMakerProtocol, beverageQuantityChecker.Object, emailNotifier.Object);
            machineLogic.InsertMoney(drinkprice);

            // act
            string sendededMessage = machineLogic.SendOrder(drinkorder.Object);

            // assert
            Assert.Equal(expectedMessage, sendededMessage);
        }
    }
}
