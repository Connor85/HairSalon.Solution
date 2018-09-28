using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{StylistId}")]
    public ActionResult Details(int StylistId)
    {
      Dictionary<string, object> model = new Dictionary <string, object>();
      Stylist selectedStylist = Stylist.Find(StylistId);
      List<Client> stylistClients = selectedStylist.GetClients();
      List<Specialty> stylistSpecialtys = selectedStylist.GetSpecialtys();
      List<Client> allClients = Client.GetAll();
      List<Specialty> allSpecialtys = Specialty.GetAll();
      model.Add("selectedStylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      model.Add("stylistSpecialtys", stylistSpecialtys);
      model.Add("allClients", allClients);
      model.Add("allSpecialtys", allSpecialtys);
      return View(model);
    }

    [HttpPost("/stylists/{StylistId}/addclient")]
    public ActionResult AddClient(int StylistId, int clientId)
    {
      Stylist foundStylist = Stylist.Find(StylistId);
      Client foundClient = Client.Find(clientId);
      foundStylist.AddClient(foundClient);
      return RedirectToAction("Details", new {StylistId = foundStylist.id});
    }

    [HttpPost("/stylists/{StylistId}/addspecialty")]
    public ActionResult AddSpecialty(int StylistId, int specialtyId)
    {
      Stylist foundStylist = Stylist.Find(StylistId);
      Specialty foundSpecialty = Specialty.Find(specialtyId);
      foundStylist.AddSpecialty(foundSpecialty);
      return RedirectToAction("Details", new {StylistId = foundStylist.id});
    }

    [HttpGet("/stylists/{stylistId}/update")]
    public ActionResult UpdateForm(int stylistId)
    {
      Stylist newStylist = Stylist.Find(stylistId);
      return View(newStylist);
    }

    [HttpPost("/stylists/{stylistId}/update")]
    public ActionResult Update(int stylistId, string newName)
    {
      Stylist newStylist = Stylist.Find(stylistId);
      newStylist.Edit(newName);
      return RedirectToAction("Details", new {StylistId = newStylist.id});
    }

    [HttpGet("/stylists/{stylistId}/delete")]
    public ActionResult DeleteItem(int stylistId)
    {
      Stylist.Delete(stylistId);
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/search")]
    public ActionResult Search()
    {
      string userInput = Request.Form["searched"];
      string searchedStylist =
      char.ToUpper(userInput[0]) + userInput.Substring(1);
      List<Stylist> foundStylists = Stylist.SearchStylist(searchedStylist);
      return View(foundStylists);
    }
  }
}
