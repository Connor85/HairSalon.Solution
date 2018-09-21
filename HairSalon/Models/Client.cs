using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    public int id {get; set;}
    public string name {get; set;}
    public string appointment {get; set;}
    public int stylist_id {get; set;}

    public Client (string clientName, string clientAppointment, int stylistId, int clientId=0)
    {
      id = clientId;
      name = clientName;
      appointment = clientAppointment;
      stylist_id = stylistId;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients  = new List<Client> ();
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM clients;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string clientName = rdr.GetString(1);
        string clientAppointment = rdr.GetString(2);
        int clientStylistId = rdr.GetInt32(3);
        int clientId = rdr.GetInt32(0);

        Client newClient = new Client(clientName, clientAppointment, clientStylistId, clientId);
        allClients.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, appointment, stylist_id) VALUES (@name, @appointment, @stylist_id);";

      MySqlParameter clientName = new MySqlParameter();
      clientName.ParameterName = "@name";
      clientName.Value = this.name;
      cmd.Parameters.Add(clientName);

      MySqlParameter clientAppointment = new MySqlParameter();
      clientAppointment.ParameterName = "@appointment";
      clientAppointment.Value = this.appointment;
      cmd.Parameters.Add(clientAppointment);

      MySqlParameter clientStylistId = new MySqlParameter();
      clientStylistId.ParameterName = "@stylist_id";
      clientStylistId.Value = this.stylist_id;
      cmd.Parameters.Add(clientStylistId);

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
      cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

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
      cmd.CommandText = @"DELETE FROM clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @searchId;";

      MySqlParameter SearchId = new MySqlParameter();
      SearchId.ParameterName = "@SearchId";
      SearchId.Value = id;
      cmd.Parameters.Add(SearchId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      string clientName = "";
      string clientAppointment = "";
      int clientStylistId = 0;

      while(rdr.Read())
      {
        clientName = rdr.GetString(1);
        clientAppointment = rdr.GetString(2);
        clientStylistId = rdr.GetInt32(3);
      }
      Client foundClient = new Client(clientName, clientAppointment, clientStylistId, id);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }

    public void Edit(string clientName, string clientAppointment, int clientStylistId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET name = @newClientName, appointment = @newClientAppointment, stylist_id = @newStylistId WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this.id;
      cmd.Parameters.Add(searchId);

      MySqlParameter newClientName = new MySqlParameter();
      newClientName.ParameterName = "@newClientName";
      newClientName.Value = clientName;
      cmd.Parameters.Add(newClientName);

      MySqlParameter newClientAppointment = new MySqlParameter();
      newClientAppointment.ParameterName = "@newClientAppointment";
      newClientAppointment.Value = clientAppointment;
      cmd.Parameters.Add(newClientAppointment);

      MySqlParameter newStylistId = new MySqlParameter();
      newStylistId.ParameterName = "@newStylistId";
      newStylistId.Value = clientStylistId;
      cmd.Parameters.Add(newStylistId);

      cmd.ExecuteNonQuery();

      this.name = clientName;
      this.appointment = clientAppointment;
      this.stylist_id = clientStylistId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
