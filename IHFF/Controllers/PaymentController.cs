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
        private PaymentRepository pr = new PaymentRepository();
        // GET: Payment
        public ActionResult Index()
        {
            //List<OrderVm> orders = (List<OrderVm>)Session["Orders"];
            List<OrderVm> orders = new List<OrderVm>();
            orders.Add(new ReservationVm()
            {
                Date = DateTime.Now,
                Count = 5,
                ProductId = 6
            });
             pr.GetOrders(orders);
            return View();
        }

    }
}