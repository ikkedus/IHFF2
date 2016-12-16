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
                //context.Movies;
                var movies = (from m in context.Movies
                              join e in context.Events on m.id equals e.Event_Id
                              join t in context.EventTimes on e.Id equals t.fk_EventId
                              select new ProductVm() {
                                  Description = m.Plot_EN,
                                 Time = t.start_Time,

                              });
            }
        }
    }
}