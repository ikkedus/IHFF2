using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class ProductRepository
    {
        public void CreateEvents()
        {
            using (DatabaseEntities ctx = new DatabaseEntities())
            {
                List<Event> ev = new List<Event>();
                
                foreach (var item in ctx.Movies)
                {
                    ev.Add(new Event()
                    {
                        Event_Id = item.id,
                        Type_Id = 2,
                        Special = false
                    });
                }
                foreach (var item in ctx.Cultures)
                {
                    ev.Add(new Event()
                    {
                        Event_Id = item.Id,
                        Type_Id = 3,
                        Special = false
                    });
                }
                foreach (var item in ctx.Restaurants)
                {
                    ev.Add(new Event()
                    {
                        Event_Id = item.Id,
                        Type_Id = 1,
                        Special = false
                    });
                }

                ctx.Events.AddRange(ev);
                ctx.SaveChanges();
            }
        }

        public void CreateProducts()
        {
            using (DatabaseEntities ctx = new DatabaseEntities())
            {
                List<Product> pr = new List<Product>();

                foreach (var item in ctx.Events)
                {
                    switch (item.Type_Id)
                    {
                        case 1:
                            pr.Add(new Product()
                            {
                                Discountable = item.Type_Id == 2,
                                fk_EventId =item.Id,
                                Name = ctx.Restaurants.Single(x=>x.Id == item.Event_Id).Name
                            });
                            break;
                        case 2:
                            pr.Add(new Product()
                            {
                                Discountable = item.Type_Id == 2,
                                fk_EventId = item.Id,
                                Name = ctx.Movies.Single(x => x.id == item.Event_Id).Title
                            });
                            break;
                        case 3:
                            pr.Add(new Product()
                            {
                                Discountable = item.Type_Id == 2,
                                fk_EventId = item.Id,
                                Name = ctx.Cultures.Single(x => x.Id == item.Event_Id).Title
                            });
                            break;
                    }
                    
                }

                ctx.Products.AddRange(pr);
                ctx.SaveChanges();
            }
        }
    }
}