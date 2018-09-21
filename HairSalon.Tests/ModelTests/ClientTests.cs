using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }
    [TestMethod]
    public void GetAll_DbStartsEmpty_0()
    {
      //Arrange
      //Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfAllAttirbutesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("John", "2018", 1);
      Client secondClient = new Client("John", "2018", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Samsung", "", 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      string firstName = "John";
      string firstAppointment = "2018/09/30";
      int firstStylistId = 1;
      Client testClient = new Client (firstName,firstAppointment,firstStylistId);
      testClient.Save();

      string secondName = "Panatda";
      string secondAppointment = "2018/09/31";
      int secondStylistId = 2;

      //Act
      testClient.Edit(secondName, secondAppointment, secondStylistId);
      Client result = Client.Find(testClient.id);

      //Assert
      Assert.AreEqual(testClient,result);
    }

    [TestMethod]
    public void Delete_DeleteClientInDatabase()
    {
      //Arrange
      Client testClient = new Client ("Apple", "", 1);
      testClient.Save();

      //Act
      Client.Delete(testClient.id);
      int count = Stylist.Find(1).GetClients().Count;

      //Assert
      Assert.AreEqual(0, count);
    }
  }
}
