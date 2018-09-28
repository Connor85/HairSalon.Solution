using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    public string name {get; set;}
    public int id {get; set;}

    public Stylist (string stylistName, int stylistId=0)
    {
      name = stylistName;
      id = stylistId;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool areIdsEqual = (this.id == newStylist.id);
        bool areNamesEqual = (this.name == newStylist.name);
        return (areIdsEqual && areNamesEqual);
      }
    }

    public override int GetHashCode()
    {
    return this.id.GetHashCode();
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
        int stylistId = rdr.GetInt32(0);

        Stylist newStylist = new Stylist(stylistName, stylistId);
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
      cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@name);";

      MySqlParameter stylistName = new MySqlParameter();
      stylistName.ParameterName = "@name";
      stylistName.Value = this.name;
      cmd.Parameters.Add(stylistName);

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

      while(rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
      }
      Stylist foundClass = new Stylist(stylistName, stylistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClass;
    }

    public void Edit(string stylistName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @newStylistName WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);

      MySqlParameter newStylistName = new MySqlParameter();
      newStylistName.ParameterName = "@newStylistName";
      newStylistName.Value = stylistName;
      cmd.Parameters.Add(newStylistName);

      cmd.ExecuteNonQuery();
      this.name = stylistName;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void AddClient(Client newClient)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@StylistId, @ClientId);";

      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = id;
      cmd.Parameters.Add(stylist_id);

      MySqlParameter client_id = new MySqlParameter();
      client_id.ParameterName = "@ClientId";
      client_id.Value = newClient.id;
      cmd.Parameters.Add(client_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Client> GetClients()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT clients.* FROM stylists
      JOIN stylists_clients ON (stylists.id = stylists_clients.stylist_id)
      JOIN clients ON (stylists_clients.client_id = clients.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = id;
      cmd.Parameters.Add(stylistIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Client> clients = new List<Client>{};

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);

        Client newClient = new Client(clientName, clientId);
        clients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clients;
    }

    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialtys_stylists (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = id;
      cmd.Parameters.Add(stylist_id);

      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = newSpecialty.id;
      cmd.Parameters.Add(specialty_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Specialty> GetSpecialtys()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialtys.* FROM stylists
      JOIN specialtys_stylists ON (stylists.id = specialtys_stylists.stylist_id)
      JOIN specialtys ON (specialtys_stylists.specialty_id = specialtys.id)
      WHERE stylists.id = @StylistId;";

      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = id;
      cmd.Parameters.Add(stylistIdParameter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Specialty> specialtys = new List<Specialty>{};

      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);

        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        specialtys.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return specialtys;
    }

    public static List<Stylist> SearchStylist(string stylistName)
    {
      List<Stylist> allStylists = new List<Stylist>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"SELECT * FROM stylists WHERE name LIKE @searchName;";

      cmd.Parameters.AddWithValue("@searchName", "%" + stylistName + "%");

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistsName = rdr.GetString(1);

        Stylist newStylist = new Stylist (stylistsName, stylistId);
        allStylists.Add(newStylist);

      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allStylists;
    }
  }
}
