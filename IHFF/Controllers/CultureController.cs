using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class CultureController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();
        // GET: Culture
        public ActionResult Index()
        {
            return View(db.Cultures.ToList());
        }
    }
}