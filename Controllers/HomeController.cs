using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropdownList.Models;

namespace DropdownList.Controllers
{
    public class HomeController : Controller
    {
        dropdownEntities db = new dropdownEntities();
        public ActionResult Index()
        {
            List<Table_Country> CountryList = db.Table_Country.ToList();
            ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName");
            return View();
        }

        public JsonResult GetStateList(int CountryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Table_State> StateList = db.Table_State.Where(x => x.CountryId == CountryId).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

    }
}