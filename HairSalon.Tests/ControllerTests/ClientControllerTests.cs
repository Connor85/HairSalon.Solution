using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;


namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest
    {
      [TestMethod]
      public void Details_ReturnsCorrectView_True()
      {
      //Arrange
      ClientController controller = new ClientController();
      Client testClient = new Client("John", 0);
      testClient.Save();

      //Act
      ActionResult detailsView = controller.Details(testClient.id);

      //Assert
      Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
    }
  }
}
