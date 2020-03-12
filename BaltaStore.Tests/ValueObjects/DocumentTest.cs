using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTest
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTest()
        {
            validDocument = new Document("03379401188");
            invalidDocument = new Document("12345678910");

        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);

        }
        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
