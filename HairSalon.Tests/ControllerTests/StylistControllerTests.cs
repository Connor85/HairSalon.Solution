using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;


namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest : IDisposable
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
      StylistController controller = new StylistController();
      Stylist testStylist = new Stylist("John", 0);
      testStylist.Save();

      //Act
      ActionResult detailsView = controller.Details(testStylist.id);

      //Assert
      Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
    }
  }
}
