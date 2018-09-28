using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;


namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyControllerTest
    {
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
