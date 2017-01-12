using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ManageController : Controller
    {
        private PaymentRepository pr = new PaymentRepository();
        private ManageRepository mr = new ManageRepository();
        // GET: Manage
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Culture()
        {
            return View("Culture/Culture", mr.GetCultureItems());
        }
        public ActionResult Sales()
        {
            return View(pr.GetPayments());
        }

        public ActionResult AddCulture()
        {
            return View("Culture/AddCulture");
        }

        [HttpPost]
        public ActionResult AddCulture(Culture culture)
        {
            mr.SaveNewCulture(culture);
            return View("Culture/Culture");
        }

        public ActionResult EditCulture(Culture culture)
        {
            return View("Culture/EditCulture");
        }

        [HttpPost]
        public ActionResult EditCulture()
        {
            return View("Culture/Culture");
        }

        public ActionResult Locations()
        {
            return View("Locations/Locations", mr.GetLocationItems());
        }

        public ActionResult AddLocation()
        {
            return View("Locations/AddLocation");
        }

        [HttpPost]
        public ActionResult AddLocation(Location location)
        {
            mr.SaveNewLocation(location);
            return View("Locations/Locations");
        }
    }
}