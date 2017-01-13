using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class RestaurantRepository
    {
        public List<RestaurantsMetProductId> getRestaurants()
        {
            using (DatabaseEntities dbs = new DatabaseEntities())
            {
                return dbs.RestaurantsMetProductIds.ToList();
            }

        }

    }
}