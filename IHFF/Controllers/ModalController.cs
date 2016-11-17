using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ModalController : Controller
    {
        // GET: Modal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            return PartialView();
        }
        public ActionResult AddItem()
        {
            if (true)//if zaal 13 pathe bijvoorbeeld
            {
                return PartialView("additemWithSeat");
            }
            return PartialView();
        }
    }
}