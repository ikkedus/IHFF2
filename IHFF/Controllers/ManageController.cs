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
        // GET: Manage
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Culture()
        {
            return View();
        }
        public ActionResult Sales()
        {
            return View(pr.GetPayments());
        }
    }
}