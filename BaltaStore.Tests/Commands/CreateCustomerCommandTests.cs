using BaltaStore.Domain.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Lucas";
            command.LastName = "Valenzuela";
            command.Document = "03379401188";
            command.Email = "lucasbezerra@gmail.com";
            command.Phone = "5561993537517";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
