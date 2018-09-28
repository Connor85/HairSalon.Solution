using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=chan_lee_test;";
    }
    public static void DeleteJoin()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialtys_stylists;DELETE FROM stylists_clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
      Specialty.DeleteAll();
      ClientTests.DeleteJoin();
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
      Client firstClient = new Client("John", 1);
      Client secondClient = new Client("John", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Samsung",1);

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
      Client testClient = new Client (firstName);
      testClient.Save();

      string secondName = "Panatda";

      //Act
      testClient.Edit(secondName);
      Client result = Client.Find(testClient.id);

      //Assert
      Assert.AreEqual(testClient,result);
    }

    [TestMethod]
    public void Delete_DeleteClientInDatabase_Null()
    {
      //Arrange
      Client testClient = new Client ("Apple",  1);
      testClient.Save();

      //Act
      Client.Delete(testClient.id);
      int count = Stylist.Find(1).GetClients().Count;

      //Assert
      Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void GetStylists_ReturnMatchingStylists_List()
    {
      //Arrange
      Client testClient = new Client ("John");
      testClient.Save();
      Stylist testStylist1 = new Stylist("stylists1");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("stylists2");
      testStylist2.Save();
      testClient.AddStylist(testStylist1);
      testClient.AddStylist(testStylist2);
      List <Stylist> expectedStylist = new List<Stylist>{testStylist1, testStylist2};

      //Act
      List <Stylist> stylists = testClient.GetStylists();

      //Assert
      CollectionAssert.AreEqual(expectedStylist, stylists);
    }
  }
}
