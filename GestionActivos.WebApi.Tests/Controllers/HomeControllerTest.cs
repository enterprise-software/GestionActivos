using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionActivos.WebApi;
using GestionActivos.WebApi.Controllers;

namespace GestionActivos.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
