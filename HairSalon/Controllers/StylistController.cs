using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace AssetAllocation.Controllers
{
    public class AssetClassController : Controller
    {
      [HttpGet("/asset-classes")]
      public ActionResult Index()
      {
        List<AssetClass> allAssetClasses = AssetClass.GetAll();
        return View(allAssetClasses);
      }

      [HttpGet("/asset-classes/new")]
      public ActionResult CreateForm()
      {
        return View();
      }

      [HttpGet("/asset-classes/delete")]
      public ActionResult DeleteAll()
      {
        AssetClass.DeleteAll();
        return RedirectToAction("Index");
      }

      [HttpPost("/asset-classes")]
      public ActionResult Create(string className, int classVolume)
      {
        AssetClass newAssetClass = new AssetClass(className, classVolume);
        newAssetClass.Save();
        return RedirectToAction("Index");
      }

      [HttpGet("/asset-classes/{id}")]
      public ActionResult Details(int id)
      {
        AssetClass thisClass = AssetClass.Find(id);
        return View(thisClass);
      }
    }
}
