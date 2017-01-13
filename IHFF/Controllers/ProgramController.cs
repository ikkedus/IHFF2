using IHFF.Helpers;
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        PaymentRepository pr = new PaymentRepository();
        // GET: Payment
        public ActionResult Index()
        {
            var program = (List<ProductVm>)Session["Program"];
            List<ProductVm> pro = pr.GetProductsForCart(program);
            return View(new OrderVm() { products = pro });
        }
        [HttpPost]
        public string AddProductToProgram(int id, int amount)
        {
            var program = (List<ProductVm>)Session["Program"] ?? new List<ProductVm>();
            if (program.Any(x => x.ProductId == id))
            {
                program.SingleOrDefault(x => x.ProductId == id).Attendanties += amount;
            }
            else
            {
                program.Add(item: new ProductVm()
                {
                    ProductId = id,
                    Attendanties = amount
                });
            }
            Session["Program"] = program;

            return program.Count().ToString();

        }
        [HttpPost]
        public string AddReservationToProgram(int id, int amount, DateTime date)
        {
            var program = (List<ProductVm>)Session["Program"] ?? new List<ProductVm>();
            if (program.Any(x => x.ProductId == id && x.Time == date))
            {
                program.SingleOrDefault(x => x.ProductId == id && x.Time == date).Attendanties += amount;
            }
            else
            {
                program.Add(item: new ProductVm()
                {
                    ProductId = id,
                    Attendanties = amount,
                    Time = date
                });
            }

            Session["Program"] = program;
            return program.Count().ToString();
        }

        [HttpPost]
        public void AddProgramToCart()
        {
            Session["Cart"] = Session["Program"];
            Session["Program"] = null;
        }

        [HttpPost]
        public ActionResult Process(OrderVm order)
        {
            if (ModelState.IsValid && pr.ProccessOrder(order))
            {
                return RedirectToAction("Succes");
            }
            return View("Index", order);
        }
        public string GetProgram()
        {
            var program = (List<ProductVm>)Session["Program"];
            List<ProductVm> pro = null;
            if (program != null)
            {
                pro = pr.GetProductsForCart(program);
            }
            return ViewHelper.RenderPartialToString(this, "Program", pro);
        }
        public void DeleteProgram()
        {
            Session["Program"] = null;
        }
        public ActionResult Succes()
        {
            return View();
        }
    }
}