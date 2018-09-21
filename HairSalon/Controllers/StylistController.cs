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

      [HttpGet("/stylists/{id}")]
      public ActionResult Details(int id)
      {
        Stylist thisClass = Stylist.Find(id);
        return View(thisClass);
      }
    }
}
