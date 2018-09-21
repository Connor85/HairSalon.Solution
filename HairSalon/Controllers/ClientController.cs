using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("stylists/{stylistId}/clients")]
    public ActionResult Index(int stylistId)
    {
      Stylist thisStylist = Stylist.Find(stylistId);
      return View(thisStylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult CreateForm(int stylistId)
    {
      Stylist thisStylist = Stylist.Find(stylistId);
      return View(thisStylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Details(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client thisClient = Client.Find(clientId);
      Stylist thisStylist = Stylist.Find(stylistId);
      model.Add("client", thisClient);
      model.Add("stylist", thisStylist);
      return View(model);
    }


    [HttpGet("/clients/{clientId}/update")]
    public ActionResult UpdateForm(int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Stylist> allStylists = Stylist.GetAll();
      Client thisClient = Client.Find(clientId);
      model.Add("allStylists", allStylists);
      model.Add("client", thisClient);
      return View(model);
    }

    [HttpPost("/clients/{clientId}/update")]
    public ActionResult Update(int clientId, string newName, string newAppointment, int newStylistId)
    {
      Console.WriteLine(clientId);
      Console.WriteLine(newName);
      Console.WriteLine(newAppointment);
      Console.WriteLine(newStylistId);
      Client thisClient = Client.Find(clientId);
      thisClient.Edit(newName, newAppointment, newStylistId);
      return RedirectToAction("Index", new {stylistId = thisClient.stylist_id});
    }

    [HttpGet("/clients/{itemId}/delete")]
    public ActionResult DeleteClient(int itemId)
    {
      Client thisClient = Client.Find(itemId);
      Client.Delete(itemId);
      return RedirectToAction("Index", new{stylistId = thisClient.id});
    }

    [HttpPost("/clients")]
    public ActionResult Create(int clientStylistId, string clientName, string clientAppointment)
    {
      Stylist foundStylist = Stylist.Find(clientStylistId);
      Client newClient = new Client(clientName, clientAppointment, clientStylistId);
      newClient.Save();
      return RedirectToAction("Index", new {stylistId = clientStylistId});
    }
  }
}
