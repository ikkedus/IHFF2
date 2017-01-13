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

        public void SaveNewPage(Page page)
        {
            db.Pages.Add(page);
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

        public List<Page> GetPages()
        {
            return db.Pages.ToList();
        }

        public void DeleteCultureItem(Culture old_culture)
        {
            Culture culture = GetCultureItem(old_culture.Id);
            db.Cultures.Remove(culture);
            db.SaveChanges();
        }

        public void DeleteLocationItem(Location location)
        {
            db.Locations.Remove(location);
            db.SaveChanges();
        }

        public void DeletePage(Page page)
        {
            db.Pages.Remove(page);
            db.SaveChanges();
        }

        public Culture GetCultureItem(int cultureid)
        {
            return db.Cultures.SingleOrDefault(x=>x.Id == cultureid);
        }

        public Location GetLocationItem(int locationid)
        {
            return db.Locations.SingleOrDefault(x => x.Id == locationid);
        }

        public Page GetPage(string pagetitel)
        {
            return db.Pages.SingleOrDefault(x => x.Title == pagetitel);
        }
<<<<<<< HEAD
        public void SaveNewMovie(Movy movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
        public List<Movy> GetMovies()
        {
            return db.Movies.ToList();
        }
        public Movy GetMovieItem(int movieid)
        {
            return db.Movies.SingleOrDefault(x => x.id == movieid);
        }
        public void DeleteMovies(Movy old_movies)
        {
            Movy movie = GetMovieItem(old_movies.id);
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

=======

        public List<Highlight> GetHighlights()
        {
            return db.Highlights.ToList();
        }

        public Highlight GetHighlight(int highlightid)
        {
            return db.Highlights.SingleOrDefault(x => x.Id == highlightid);
        }

        public void SaveHighlight(Highlight highlight)
        {
            db.Highlights.Add(highlight);
            db.SaveChanges();
        }

        public void DeleteHighlight(Highlight highlight)
        {
            db.Highlights.Remove(highlight);
            db.SaveChanges();
        }
>>>>>>> refs/remotes/origin/Jeroen
    }
}