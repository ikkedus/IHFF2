using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class PSRepository
    {
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