using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class PaymentRepository
    {
        public void getPayments()
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
            }
        }
        public bool ProccessOrder(OrderVm order)
        {
            //OrderVm order = new OrderVm()
            //{
            //    Email = "matvandergragt@gmail.com",
            //    Lastname = "Gragt",
            //    Name = "Martin",
            //    PayemntMethod = 1,
            //    Prefix = "van der",
            //    products = new List<ProductVm>()
            //};
            //order.products.Add(new ReservationVm()
            //{
            //    Attendanties = 4,
            //    Comment = "Pinda Allergie",
            //    ProductId = 1,
            //    ReservationTime = DateTime.Now.AddHours(7),
            //});
            //order.products.Add(new Ticket()
            //{
            //    Attendanties = 3,
            //    ProductId = 2,
            //});
            List<ReservationVm> reservations = new List<ReservationVm>();
            List<Ticket> tickets = new List<Ticket>();

            foreach (var product in order.products)
            {
                if (product is Ticket)
                {
                    tickets.Add((Ticket)product);
                }
                else if (product is ReservationVm)
                {
                    reservations.Add((ReservationVm)product);
                }
            }
            using (DatabaseEntities context = new DatabaseEntities())
            {
                Customer cus = createCustomer(order);
                Order ord = createOrder(order, cus);
                List<Reservation> res = createListReservation(reservations, ord);
                List<ProductInOrder> proInOrd = createListProductInOrder(tickets, ord);

                context.Customers.Add(cus);
                context.Orders.Add(ord);
                context.Reservations.AddRange(res);
                context.ProductInOrders.AddRange(proInOrd);
                context.SaveChanges();
            }

            return false;
        }

        private static List<ProductInOrder> createListProductInOrder(List<Ticket> tickets, Order ord)
        {
            return (from t in tickets
                    select new ProductInOrder()
                    {
                        Amount = t.Attendanties,
                        fk_Product_id = t.ProductId,
                        fk_Order_id = ord.Id,
                    }).ToList();
        }

        private static List<Reservation> createListReservation(List<ReservationVm> reservations, Order ord)
        {
            return (from r in reservations
                    select new Reservation()
                    {
                        Comment = r.Comment,
                        ReservationDate = r.ReservationTime,
                        fk_Order_Id = ord.Id,
                    }).ToList();
        }

        private static Order createOrder(OrderVm order, Customer cus)
        {
            return new Order()
            {
                Date = DateTime.Now,
                fk_Client = cus.Id,
                Paymentmethod = order.PayemntMethod,
                Status = 1,
            };
        }

        private static Customer createCustomer(OrderVm order)
        {
            return new Customer()
            {
                Name = order.Name,
                lastName = order.Lastname,
                Prefix = order.Prefix,
                Email = order.Email,
                Createdon = DateTime.Now
            };
        }
    }
}