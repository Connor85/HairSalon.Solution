using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string name {get; set;}
    public int income {get; set;}
    public int id {get; set;}

    public Stylist (string stylistName, int stylistIncome, int stylistId=0)
    {
      name = stylistName;
      income = stylistIncome;
      id = stylistId;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists  = new List<Stylist> ();
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM stylists;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string stylistName = rdr.GetString(1);
        int stylistIncome = rdr.GetInt32(2);
        int stylistId = rdr.GetInt32(0);

        Stylist newStylist = new Stylist(stylistName, stylistIncome, stylistId);
        allStylists.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, income) VALUES (@name, @income);";

      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@name";
      stylistName.Value = this.name;
      cmd.Parameters.Add(stylistName);

      MySqlParameter stylistIncome = new MySqlParameter();
      stylistIncome.ParameterName = "@income";
      stylistIncome.Value = this.income;
      cmd.Parameters.Add(stylistIncome);

      cmd.ExecuteNonQuery();
      id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @searchId;";

      MySqlParameter SearchId = new MySqlParameter();
      SearchId.ParameterName = "@SearchId";
      SearchId.Value = id;
      cmd.Parameters.Add(SearchId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistId = 0;
      string stylistName = "";
      int stylistIncome = 0;

      while(rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
      }
      Stylist foundClass = new Stylist(stylistName, stylistIncome, stylistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClass;
    }

    public void Edit(string stylistName, int stylistIncome)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @newStylistName, income = @newStylistIncome WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);

      MySqlParameter newStylistName = new MySqlParameter();
      newStylistName.ParameterName = "@newStylistName";
      newStylistName.Value = stylistName;
      cmd.Parameters.Add(newStylistName);

      MySqlParameter newStylistIncome = new MySqlParameter();
      newStylistIncome.ParameterName = "@newStylistIncome";
      newStylistIncome.Value = stylistIncome;
      cmd.Parameters.Add(newStylistIncome);

      cmd.ExecuteNonQuery();
      this.name = stylistName;
      this.income = stylistIncome;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Client> GetClients()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";

      MySqlParameter thisStylistId = new MySqlParameter();
      thisStylistId.ParameterName = "@stylist_id";
      thisStylistId.Value = this.id;
      cmd.Parameters.Add(thisStylistId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int id = 0;
      string name = "";
      string appointment = "";
      int stylist_id = 0;
      while(rdr.Read())
      {
          id = rdr.GetInt32(0);
          name = rdr.GetString(1);
          appointment = rdr.GetString(2);
          stylist_id = rdr.GetInt32(3);
          Client newClient = new Client(name, appointment, stylist_id, id);
          allClients.Add(newClient);
      }
      conn.Close();
      if(conn != null)
      {
          conn.Dispose();
      }
      return allClients;
    }
  }
}
