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
      List<Client> allClients = thisStylist.GetClients();
      return View(allClients);
    }

    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult CreateForm(int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Stylist> allStylists = Stylist.GetAll();
      Stylist thisStylist = Stylist.Find(stylistId);
      model.Add("allStylists", allStylists);
      model.Add("thisStylist", thisStylist);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Details(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client thisClient = Client.Find(clientId);
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }


    [HttpGet("/clients/{clientId}/update")]
    public ActionResult UpdateForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Stylist> allStylists = Stylist.GetAll();
      Client thisClient = Client.Find(id);
      model.Add("allStylists", allStylists);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/clients/{clientId}/update")]
    public ActionResult Update(int id, string newName, string newAppointment, int newStylistId)
    {
      Client thisClient = Client.Find(id);
      thisClient.Edit(newName, newAppointment, newStylistId);
      return RedirectToAction("Index", new {stylistId = thisClient.id});
    }

    [HttpGet("/clients/{itemId}/delete")]
    public ActionResult DeleteClient(int itemId)
    {
      Client thisClient = Client.Find(itemId)
      Client.Delete(itemId);
      return RedirectToAction("Index", new{stylistId = thisClient.id});
    }


  }
}
