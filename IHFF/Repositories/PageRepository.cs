using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class PageRepository
    {
        private DatabaseEntities db = new DatabaseEntities();

        public Page GetPage(string title)
        {
            return db.Pages.SingleOrDefault(x => x.Title == title);
        }
    }
}