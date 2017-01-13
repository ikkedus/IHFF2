using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class PSController : Controller
    {
        PSRepository psr = new PSRepository();
        // GET: PS
        public ActionResult Index()
        {
            var program = (List<ProductVm>)Session["PS"];
            List<ProductVm> programlist = psr.GetProductsForCart(program);
            return View(programlist);
        }

        //[HttpPost]
        //public string AddReservationToProgram(int id)
        //{
        //    var program = (List<ProductVm>)Session["PS"] ?? new List<ProductVm>();
        //    program.Add(item: new ProductVm()
        //        {
        //        ProductId = id,
        //        Attendanties = amount,
        //        Time = date
        //    } );
        //    Session["PS"] = program;
        //    return "Added";
        //}

        [HttpPost]
        public string AddProductToCart(int id, int amount)
        {
            var cart = (List<ProductVm>)Session["PS"] ?? new List<ProductVm>();
            cart.Add(item: new ProductVm()
            {
                ProductId = id,
                Attendanties = amount
            });
            Session["PS"] = cart;
            return "Added";
        }

        public ActionResult AddToChart()
        {
            return View("Chart");
        }
    }
}