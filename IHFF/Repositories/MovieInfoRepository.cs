using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class MovieInfoRepository
    {
        public List<MovieInfoItem> getInfoMovies()
        {
            using (DatabaseEntities context = new DatabaseEntities())
            {
                List<MovieInfoItem> items = (from m in context.Movies
                                             join e in context.Events on m.id equals e.Event_Id
                                             where e.Type_Id == 2
                                             where m.id == 6
                                             select new MovieInfoItem()
                                             {
                                                 id = m.id,
                                                 title = m.Title,
                                                 plot_EN = m.Plot_EN,
                                                 plot_NL = m.Plot_NL,
                                                 banner = m.Banner,
                                                 director = m.Director,
                                                 duration = m.Duration,
                                                 trailer = m.Trailer,
                                                 releasedate = m.Release,
                                                 actor = m.Actors,
                                                 Eventid = e.Id,
                                                 times = (from t in context.EventTimes
                                                          join l in context.Locations on t.fk_Location equals l.Id
                                                          where t.fk_EventId == e.Id
                                                          select new Times()
                                                          {
                                                              day = (DayOfWeek)t.Day,
                                                              End = t.end_Time,
                                                              Start = t.start_Time,
                                                              Location = l.Name,
                                                          }).ToList()
                                             }).ToList();
                return items;
            }
        }
    }
}