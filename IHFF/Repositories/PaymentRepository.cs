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
            using (DatabaseEntities context = new DatabaseEntities())
            {
                Customer cus = createCustomer(order);
                Order ord = createOrder(order, cus);
                List<Reservation> res = createListReservation(order.products, ord);
                List<ProductInOrder> proInOrd = createListProductInOrder(order.products, ord);

                context.Customers.Add(cus);
                context.Orders.Add(ord);
                context.Reservations.AddRange(res);
                context.ProductInOrders.AddRange(proInOrd);
                context.SaveChanges();
            }

            return false;
        }

        private static List<ProductInOrder> createListProductInOrder(List<ProductVm> tickets, Order ord)
        {
            return (from t in tickets
                    select new ProductInOrder()
                    {
                        Amount = t.Attendanties,
                        fk_Product_id = t.ProductId,
                        fk_Order_id = ord.Id,
                    }).ToList();
        }

        private static List<Reservation> createListReservation(List<ProductVm> reservations, Order ord)
        {
            return (from r in reservations
                    select new Reservation()
                    {
                        Comment = r.Comment,
                        ReservationDate = r.Time,
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