using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class MoviesRepository
    {
        public void getMovies()
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                context.Movies.Add(new Movy());
            }
        }
    }
}