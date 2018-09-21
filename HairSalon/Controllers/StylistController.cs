using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace AssetAllocation.Controllers
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

      [HttpGet("/stylists/delete")]
      public ActionResult DeleteAll()
      {
        Stylist.DeleteAll();
        return RedirectToAction("Index");
      }

      [HttpPost("/stylists")]
      public ActionResult Create(string stylistName, int stylistIncome)
      {
        Stylist newStylist = new Stylist(stylistName, stylistIncome);
        newStylist.Save();
        return RedirectToAction("Index");
      }

      [HttpGet("/stylists/{StylistId}")]
      public ActionResult Details(int StylistId)
      {
        Stylist thisClass = Stylist.Find(StylistId);
        return View(thisClass);
      }

      [HttpGet("/stylists/{stylistId}/update")]
      public ActionResult UpdateForm(int stylistId)
      {
          Stylist newStylist = Stylist.Find(stylistId);
          return View(newStylist);
      }

      [HttpPost("/stylists/{stylistId}/update")]
      public ActionResult Update(int stylistId, string newName, int newIncome)
      {
          Stylist newStylist = Stylist.Find(stylistId);
          newStylist.Edit(newName, newIncome);
          return RedirectToAction("Details", new {StylistId = newStylist.id});
      }

      [HttpGet("/stylists/{stylistId}/delete")]
      public ActionResult DeleteItem(int stylistId)
      {
          // Stylist newStylist = Stylist.Find(stylistId);
          Stylist.Delete(stylistId);
          return RedirectToAction("Index");
      }
    }
}
