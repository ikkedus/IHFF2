using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;

namespace IHFF.Controllers
{
    public class RestaurantsController : Controller
    {

        RestaurantRepository rr = new RestaurantRepository();

        public ActionResult Index()
        {
            return View(rr.getRestaurants());
        }
    }
}
