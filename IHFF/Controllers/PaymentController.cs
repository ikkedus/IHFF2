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
    public class PaymentController : Controller
    {
        PaymentRepository pr = new PaymentRepository();
        // GET: Payment
        public ActionResult Index()
        {
            var cart = (List<ProductVm>) Session["Cart"];
            List<ProductVm> pro = pr.GetProductsForCart(cart);
            //Get p8roducts
            //List<ProductVm> pro = new List<ProductVm>();
            //pro.Add(new ProductVm()
            //{
            //    Attendanties = 4,
            //    Comment = "Pinda Allergie",
            //    ProductId = 1,
            //    Time = DateTime.Now.AddHours(7),
            //    Poster = "https://s-media-cache-ak0.pinimg.com/564x/e0/65/ec/e065ecda517b1efe0e3034ec17bcc4b8.jpg",
            //    Title = "The Pop Up kitchen",
            //    IsRestaurant = true,
            //    Description = "The Pop Up Kitchen is a revolutionarie idee created by the sisters Amber Lee and Ashtley Lee. together the bring exotic dishes to festivals over the content"
            //});
            //pro.Add(new ProductVm()
            //{
            //    Title = "Tron",
            //    Poster = "https://s-media-cache-ak0.pinimg.com/originals/0c/2d/bd/0c2dbd1bc5f6e4ba2e519d43c1613484.jpg",
            //    Attendanties = 3,
            //    ProductId = 2,
            //    Description = "Hacker/arcade owner Kevin Flynn is digitally broken down into a data stream by a villainous software pirate known as Master Control and reconstituted into the internal, 3-D graphical world of computers. It is there, in the ultimate blazingly colorful, geometrically intense landscapes of cyberspace, that Flynn joins forces with Tron to outmaneuver the Master Control Program that holds them captive in the equivalent of a gigantic, infinitely challenging computer game."
            //});
            return View(new OrderVm() { products = pro });
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
<<<<<<< HEAD
            return cart.Count().ToString();
=======
            return cart.Count.ToString();
>>>>>>> origin/master
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
            if (ModelState.IsValid && pr.ProccessOrder(order))
            {
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