using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
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
    int result = Stylist.GetAll().Count;

    //Assert
    Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Stylist()
    {
    //Arrange, Act
    Stylist firstStylist = new Stylist("John", 1);
    Stylist secondStylist = new Stylist("John", 1);

    //Assert
    Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Harry",1);
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
    //Arrange
    Stylist testStylist = new Stylist("John", 0);
    testStylist.Save();

    //Act
    Stylist savedStylist = Stylist.GetAll()[0];

    int result = savedStylist.id;
    int testId = testStylist.id;

    //Assert
    Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
    //Arrange
    Stylist testStylist = new Stylist("John", 0);
    testStylist.Save();

    //Act
    Stylist foundStylist = Stylist.Find(testStylist.id);

    //Assert
    Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void Edit_UpdatesStylistInDatabase_String()
    {
      //Arrange
      string firstName = "John";
      Stylist testStylist = new Stylist (firstName);
      testStylist.Save();

      string secondName = "Panatda";

      //Act
      testStylist.Edit(secondName);
      Stylist result = Stylist.Find(testStylist.id);

      //Assert
      Assert.AreEqual(testStylist,result);
    }

    [TestMethod]
    public void Delete_DeleteStylistInDatabase_Null()
    {
      //Arrange
      Stylist testStylist = new Stylist ("John");
      testStylist.Save();
      int testStylistId = testStylist.id;

      //Act
      Stylist.Delete(testStylistId);
      int count = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void GetClients_ReturnMatchingClients_List()
    {
      //Arrange
      Stylist testStylist = new Stylist ("John");
      testStylist.Save();
      Client testClient1 = new Client("clients1");
      testClient1.Save();
      Client testClient2 = new Client("clients2");
      testClient2.Save();
      testStylist.AddClient(testClient1);
      testStylist.AddClient(testClient2);
      List <Client> expectedClient = new List<Client>{testClient1, testClient2};

      //Act
      List <Client> clients = testStylist.GetClients();

      //Assert
      CollectionAssert.AreEqual(expectedClient, clients);
    }
  }
}
