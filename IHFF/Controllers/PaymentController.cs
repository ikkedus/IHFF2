using IHFF.Helpers;
using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class PaymentController : Controller
    {
        PaymentRepository pr = new PaymentRepository();
        // GET: Payment
        public ActionResult Index()
        {
            var cart = (List<ProductVm>) Session["Cart"];
            return View(pr.GetOrder(cart));
        }
        [HttpPost]
        public string AddProductToCart(int id, int amount)
        {
            var cart = (List<ProductVm>)Session["Cart"] ?? new List<ProductVm>();
            if (cart.Any(x => x.ProductId == id))
            {
                cart.SingleOrDefault(x => x.ProductId == id).Attendanties += amount;
            }
            else { 
            cart.Add(item: new ProductVm()
            {
                ProductId = id,
                Attendanties = amount
            });
            }
            Session["Cart"] = cart;
 
            return cart.Count().ToString();
 
        }
        [HttpPost]
        public string AddReservationToCart(int id,int amount,DateTime date)
        {
            var cart = (List<ProductVm>) Session["Cart"] ?? new List<ProductVm>();
            if (cart.Any(x=>x.ProductId  == id && x.Time == date))
            {
                cart.SingleOrDefault(x=>x.ProductId == id && x.Time == date).Attendanties += amount;
            }
            else
            {
                cart.Add(item: new ProductVm()
                {
                    ProductId = id,
                    Attendanties = amount,
                    Time = date
                });
            }
            Session["Cart"] = cart;
            return cart.Count().ToString();
        }

        [HttpPost]
        public ActionResult Process(OrderVm order)
        {
            if (ModelState.IsValid)
            {
                pr.ProccessOrder(order);
                return RedirectToAction("Succes");
            }
            return View("Index", order);
        }
        public string GetCart()
        {
            var cart = (List<ProductVm>)Session["Cart"];
            List<ProductVm> pro = null;
            if (cart != null)
            {
                pro = pr.GetProductsForCart(cart); 
            }
            return ViewHelper.RenderPartialToString(this, "Cart", pro);
            //return "Hello world";
        }
        public void DeleteCart() {
            Session["Cart"] = null;
        }
        public ActionResult Succes()
        {
            return View();
        }

    }
}