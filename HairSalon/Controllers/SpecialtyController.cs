using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialtys")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialtys = Specialty.GetAll();
      return View(allSpecialtys);
    }

    [HttpGet("/specialtys/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/specialtys")]
    public ActionResult Create(string specialtyName)
    {
      Specialty newSpecialty = new Specialty(specialtyName);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialtys/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.DeleteAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialtys/{SpecialtyId}")]
    public ActionResult Details(int SpecialtyId)
    {
      Dictionary<string, object> model = new Dictionary <string, object>();
      Specialty selectedSpecialty = Specialty.Find(SpecialtyId);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedSpecialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialtys/{SpecialtyId}")]
    public ActionResult AddStylist(int SpecialtyId, int stylistId)
    {
      Specialty foundSpecialty = Specialty.Find(SpecialtyId);
      Stylist foundStylist = Stylist.Find(stylistId);
      foundSpecialty.AddStylist(foundStylist);
      return RedirectToAction("Details", new {SpecialtyId = foundSpecialty.id});
    }

    [HttpGet("/specialtys/{specialtyId}/update")]
    public ActionResult UpdateForm(int specialtyId)
    {
      Specialty newSpecialty = Specialty.Find(specialtyId);
      return View(newSpecialty);
    }

    [HttpPost("/specialtys/{specialtyId}/update")]
    public ActionResult Update(int specialtyId, string newName)
    {
      Specialty newSpecialty = Specialty.Find(specialtyId);
      newSpecialty.Edit(newName);
      return RedirectToAction("Details", new {SpecialtyId = newSpecialty.id});
    }

    [HttpGet("/specialtys/{specialtyId}/delete")]
    public ActionResult DeleteItem(int specialtyId)
    {
      Specialty.Delete(specialtyId);
      return RedirectToAction("Index");
    }

    [HttpPost("/speicaltys/search")]
    public ActionResult Search()
    {
      string userInput = Request.Form["searched"];
      string searchedSpecialty =
      char.ToUpper(userInput[0]) + userInput.Substring(1);
      List<Specialty> foundSpecialtys = Specialty.SearchSpecialty(searchedSpecialty);
      return View(foundSpecialtys);
    }
  }
}
