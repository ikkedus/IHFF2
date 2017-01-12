using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class ManageRepository
    {
        private DatabaseEntities db = new DatabaseEntities();

        public void SaveNewLocation(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }

        public void SaveNewCulture(Culture culture)
        {
            db.Cultures.Add(culture);
            db.SaveChanges();
        }

        public List<Culture> GetCultureItems()
        {
            return db.Cultures.ToList();
        }

        public List<Location> GetLocationItems()
        {
            return db.Locations.ToList();
        }
    }
}