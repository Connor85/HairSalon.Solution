using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests

{
  [TestClass]
  public class HomeControllerTest : IDisposable
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
    public void Index_ReturnsCorrectView_True()
    {
    //Arrange
    HomeController controller = new HomeController();

    //Act
    ActionResult indexView = controller.Index();

    //Assert
    Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
