using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTest
    {

        [TestMethod]
        public void ShouldReturnNotificationWhenNametIsNotValid()
        {
            var name = new Name("AA", "BB");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(2, name.Notifications.Count);

        }
        [TestMethod]
        public void ShouldReturnNotificationWhenNametIsValid()
        {
            var name = new Name("Lucas", "Valenzuela");
            Assert.AreEqual(true, name.IsValid);
            Assert.AreEqual(0, name.Notifications.Count);
        }
    }
}
