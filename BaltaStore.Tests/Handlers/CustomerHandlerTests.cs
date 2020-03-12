using BaltaStore.Domain.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Lucas";
            command.LastName = "Valenzuela";
            command.Document = "03379401188";
            command.Email = "lucasbezerra@gmail.com";
            command.Phone = "5561993537517";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, handler.IsValid);
        }
    }
}
