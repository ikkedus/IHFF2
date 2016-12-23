using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class CultureRepository
    {
        public List<Cultureitem> GetCultureitems()
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                List<Cultureitem> items = (from c in context.Cultures
                                           join l in context.Locations on c.Title equals l.Name
                                           select new Cultureitem() {
                                               contact = l.Contact,
                                               description_EN = c.Description_EN,
                                               description_NL = c.Description_NL,
                                               poster = c.Poster,
                                               street = l.Street,
                                               streetnumber = l.Streetnumber,
                                               title = c.Title,
                                               maps = l.Maps,
                                               openinghours1_EN = c.Openinghours1_EN,
                                               openinghours2_EN = c.Openinghours2_EN,
                                               openinghours1_NL = c.Openinghours1_NL,
                                               openinghours2_NL = c.Openinghours2_NL
                                           }).ToList();

                return items;
            }
        }
    }
}