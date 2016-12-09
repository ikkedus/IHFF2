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
                context.Orders.Add(new Order());
            }
        }

        internal List<object> GetOrders(List<OrderVm> orders)
        {
            foreach (var item in orders)
            {
                dynamic d = item;
                Process(d);
            }
            return null;
        }
        public void Process(MovieVm order)
        {

        }
        public void Process(ReservationVm order)
        {

        }

    }
}