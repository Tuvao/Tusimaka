using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enhetstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Liste()
        {
            //denne tester kun på en metode som kun returnerer et view
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            // Act
            var resultat = (ViewResult)controller.Registrer();
            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            public ActionResult RegistrerKunde()
            {
                return View();
            }
            return View();
            }
            //Arrange
            //Act
            //Assert
        }
    }
}
