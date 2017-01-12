using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class PageController : Controller
    {
        private PageRepository repo = new PageRepository();

        public ActionResult Index(string title)
        {
            //vraagt titel op om te kijken welke pagina het is
            Page page = repo.GetPage(title);
            //als de pagina niet bestaat return to home
            if (page == null)
            {
                return RedirectToAction("index", "Home", null);
            }
            return View(page.Title,page);
        }
    }
}