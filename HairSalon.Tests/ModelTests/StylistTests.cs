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
    DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }
    public void Dispose()
    {
    Client.DeleteAll();
    Stylist.DeleteAll();
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
    Stylist firstStylist = new Stylist("John", 0, 1);
    Stylist secondStylist = new Stylist("John", 0, 1);

    //Assert
    Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Harry", 0, 1);
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
    public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    {
    Stylist testStylist = new Stylist("John", 0);
    testStylist.Save();

    Client firstClient = new Client("Jack", "", testStylist.id);
    firstClient.Save();
    Client secondClient = new Client("Jill", "", testStylist.id);
    secondClient.Save();

    List<Client> testClientList = new List<Client> {firstClient, secondClient};
    List<Client> resultClientList = testStylist.GetClients();

    CollectionAssert.AreEqual(testClientList, resultClientList);
    }
  }
}
