using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;


namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyControllerTest : IDisposable
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
      SpecialtyController controller = new SpecialtyController();
      Specialty testSpecialty = new Specialty("John", 0);
      testSpecialty.Save();

      //Act
      ActionResult detailsView = controller.Details(testSpecialty.id);

      //Assert
      Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
    }
  }
}
