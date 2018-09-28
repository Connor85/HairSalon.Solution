using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Specialty
  {
    public string name {get; set;}
    public int id {get; set;}

    public Specialty (string specialtyName, int specialtyId=0)
    {
      name = specialtyName;
      id = specialtyId;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool areIdsEqual = (this.id == newSpecialty.id);
        bool areNamesEqual = (this.name == newSpecialty.name);
        return (areIdsEqual && areNamesEqual);
      }
    }

    public override int GetHashCode()
    {
    return this.id.GetHashCode();
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialtys  = new List<Specialty> ();
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM specialtys;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string specialtyName = rdr.GetString(1);
        int specialtyId = rdr.GetInt32(0);

        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        allSpecialtys.Add(newSpecialty);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialtys;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialtys (name) VALUES (@name);";

      MySqlParameter specialtyName = new MySqlParameter();
      specialtyName.ParameterName = "@name";
      specialtyName.Value = this.name;
      cmd.Parameters.Add(specialtyName);

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
      cmd.CommandText = @"DELETE FROM specialtys WHERE id = @thisId;";

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
      cmd.CommandText = @"DELETE FROM specialtys;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialtys WHERE id = @searchId;";

      MySqlParameter SearchId = new MySqlParameter();
      SearchId.ParameterName = "@SearchId";
      SearchId.Value = id;
      cmd.Parameters.Add(SearchId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int specialtyId = 0;
      string specialtyName = "";

      while(rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        specialtyName = rdr.GetString(1);
      }
      Specialty foundClass = new Specialty(specialtyName, specialtyId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClass;
    }

    public void Edit(string specialtyName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialtys SET name = @newSpecialtyName WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);

      MySqlParameter newSpecialtyName = new MySqlParameter();
      newSpecialtyName.ParameterName = "@newSpecialtyName";
      newSpecialtyName.Value = specialtyName;
      cmd.Parameters.Add(newSpecialtyName);

      cmd.ExecuteNonQuery();
      this.name = specialtyName;

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
      cmd.CommandText = @"INSERT INTO specialtys_clients (specialty_id, client_id) VALUES (@SpecialtyId, @ClientId);";

      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = id;
      cmd.Parameters.Add(specialty_id);

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
      cmd.CommandText = @"SELECT clients.* FROM specialtys
      JOIN specialtys_clients ON (specialtys.id = specialtys_clients.specialty_id)
      JOIN clients ON (specialtys_clients.client_id = clients.id)
      WHERE specialtys.id = @SpecialtyId;";

      MySqlParameter specialtyIdParameter = new MySqlParameter();
      specialtyIdParameter.ParameterName = "@SpecialtyId";
      specialtyIdParameter.Value = id;
      cmd.Parameters.Add(specialtyIdParameter);

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
  }
}
