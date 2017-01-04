using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class PaymentRepository
    {
        public List<Payment> GetPayments()
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                return (from ord in context.Orders
                        select new Payment()
                        {
                            PaymentOption = ord.Paymentmethod.ToString(),
                            products = (from pio in context.ProductInOrders
                                        where pio.fk_Order_id == ord.Id
                                        select pio.Amount).Sum(x => x),
                            status = ord.Status,
                        }).ToList();
            }
        }
        public bool ProccessOrder(OrderVm order)
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                Customer cus = CreateCustomer(order);
                Order ord = CreateOrder(order, cus);
                List<Reservation> res = CreateListReservation(order.products.Where(x=>x.IsRestaurant).ToList(), ord);
                List<ProductInOrder> proInOrd = CreateListProductInOrder(order.products.Where(x => !x.IsRestaurant).ToList(), ord);

                context.Customers.Add(cus);
                
                context.SaveChanges();
                ord.fk_Client = cus.Id;
                context.Orders.Add(ord);
                context.SaveChanges();
                res.ForEach(x=>x.fk_Order_Id = ord.Id);
                proInOrd.ForEach(x=>x.fk_Order_id = ord.Id);
                context.Reservations.AddRange(res);
                context.ProductInOrders.AddRange(proInOrd);
                context.SaveChanges();
            }

            return false;
        }

        private static List<ProductInOrder> CreateListProductInOrder(List<ProductVm> tickets, Order ord)
        {
            return (from t in tickets
                    select new ProductInOrder()
                    {
                        Amount = t.Attendanties,
                        fk_Product_id = t.ProductId,
                        fk_Order_id = ord.Id,
                    }).ToList();
        }

        private static List<Reservation> CreateListReservation(List<ProductVm> reservations, Order ord)
        {
            return (from r in reservations
                    select new Reservation()
                    {
                        Comment = r.Comment,
                        ReservationDate = r.Time,
                        fk_Order_Id = ord.Id,
                    }).ToList();
        }

        private static Order CreateOrder(OrderVm order, Customer cus)
        {
            return new Order()
            {
                Date = DateTime.Now,
                fk_Client = cus.Id,
                Paymentmethod = order.PayemntMethod,
                Status = 1,
            };
        }

        private static Customer CreateCustomer(OrderVm order)
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
        //omdat luke erom vraagt
        public List<ProductVm> GetProductsForCart(List<ProductVm> cart)
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                var cartItems = (from c in cart
                                 join p in context.Products on c.ProductId equals p.Id
                                 join e in context.Events on p.fk_EventId equals e.Id
                                 join m in context.Movies on e.Event_Id equals m.id into mo
                                 from m in mo.DefaultIfEmpty()
                                 join cul in context.Cultures on e.Event_Id equals cul.Id into cult
                                 from cul in cult.DefaultIfEmpty()
                                 join r in context.Restaurants on e.Event_Id equals r.Id into res
                                 from r in res.DefaultIfEmpty()
                                 select new ProductVm()
                                 {
                                     Attendanties = c.Attendanties,
                                     IsRestaurant = c.Time != new DateTime(),
                                     Time = c.Time != new DateTime() ? c.Time : DateTime.Now,
                                     ProductId = p.Id,
                                     Poster = e.Type_Id == 1 ? r.Poster :
                                                e.Type_Id == 2 ? m.poster :
                                                cul.Poster,
                                     Title = e.Type_Id == 1 ? r.Name :
                                                e.Type_Id == 2 ? m.Title :
                                                cul.Title,
                                     Description = e.Type_Id == 1 ? r.Description_EN :
                                                e.Type_Id == 2 ? m.Plot_EN :
                                                cul.Description_EN,
                                 }).ToList();
                return cartItems;
            }
        }
    }
}