using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class CultureController : Controller
    {
        private CultureRepository repo = new CultureRepository();
        // GET: Culture
        public ActionResult Index()
        {
            return View(repo.GetCultureitems());
        }
    }
}