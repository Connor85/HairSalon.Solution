using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;


namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=chan_lee_test;";
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
      Specialty.DeleteAll();
    }
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
