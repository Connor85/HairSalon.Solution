using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
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
    public void GetAll_DBEmptyAtFirst_0()
    {
    //Arrange, Act
    int result = Specialty.GetAll().Count;

    //Assert
    Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Specialty()
    {
    //Arrange, Act
    Specialty firstSpecialty = new Specialty("Color", 1);
    Specialty secondSpecialty = new Specialty("Color", 1);

    //Assert
    Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Updo",1);
      testSpecialty.Save();

      //Act
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToSpecialty_Id()
    {
    //Arrange
    Specialty testSpecialty = new Specialty("Color", 0);
    testSpecialty.Save();

    //Act
    Specialty savedSpecialty = Specialty.GetAll()[0];

    int result = savedSpecialty.id;
    int testId = testSpecialty.id;

    //Assert
    Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_FindsSpecialtyInDatabase_Specialty()
    {
    //Arrange
    Specialty testSpecialty = new Specialty("Color", 0);
    testSpecialty.Save();

    //Act
    Specialty foundSpecialty = Specialty.Find(testSpecialty.id);

    //Assert
    Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Edit_UpdatesSpecialtyInDatabase_String()
    {
      //Arrange
      string firstName = "Color";
      Specialty testSpecialty = new Specialty (firstName);
      testSpecialty.Save();

      string secondName = "Dry";

      //Act
      testSpecialty.Edit(secondName);
      Specialty result = Specialty.Find(testSpecialty.id);

      //Assert
      Assert.AreEqual(testSpecialty,result);
    }

    [TestMethod]
    public void Delete_DeleteSpecialtyInDatabase_Null()
    {
      //Arrange
      Specialty testSpecialty = new Specialty ("Color");
      testSpecialty.Save();
      int testSpecialtyId = testSpecialty.id;

      //Act
      Specialty.Delete(testSpecialtyId);
      int count = Specialty.GetAll().Count;

      //Assert
      Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void GetStylists_ReturnMatchingStylists_List()
    {
      //Arrange
      Specialty testSpecialty = new Specialty ("Color");
      testSpecialty.Save();
      Stylist testStylist1 = new Stylist("clients1");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("clients2");
      testStylist2.Save();
      testSpecialty.AddStylist(testStylist1);
      testSpecialty.AddStylist(testStylist2);
      List <Stylist> expectedStylist = new List<Stylist>{testStylist1, testStylist2};

      //Act
      List <Stylist> categories = testSpecialty.GetStylists();

      //Assert
      CollectionAssert.AreEqual(expectedStylist, categories);
    }
  }
}
