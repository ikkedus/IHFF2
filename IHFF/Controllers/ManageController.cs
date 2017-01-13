using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class ManageController : Controller
    {
        private PaymentRepository pr = new PaymentRepository();
        private ManageRepository mr = new ManageRepository();
        // GET: Manage
        public ActionResult Index()
        {
            return View();

        }
        
        public ActionResult Sales()
        {
            return View(pr.GetPayments());
        }

        public ActionResult Culture()
        {
            return View("Culture/Culture", mr.GetCultureItems());
        }

        public ActionResult AddCulture()
        {
            return View("Culture/AddCulture");
        }

        [HttpPost]
        public ActionResult AddCulture(Culture culture)
        {
            mr.SaveNewCulture(culture);
            return View("Culture/Culture", mr.GetCultureItems());
        }

        public ActionResult EditCulture(Culture oldculture)
        {
            return View("Culture/EditCulture", oldculture);
        }

        [HttpPost]
        public ActionResult EditCulture(Culture newculture, int Id)
        {
            mr.DeleteCultureItem(mr.GetCultureItem(newculture.Id));
            mr.SaveNewCulture(newculture);
            return View("Culture/Culture", mr.GetCultureItems());
        }

        public ActionResult DeleteCulture(Culture culture)
        {
            mr.DeleteCultureItem(culture);
            return View("Culture/Culture", mr.GetCultureItems());
        }

        public ActionResult Locations()
        {
            return View("Locations/Locations", mr.GetLocationItems());
        }

        public ActionResult AddLocation()
        {
            return View("Locations/AddLocation");
        }

        [HttpPost]
        public ActionResult AddLocation(Location location)
        {
            mr.SaveNewLocation(location);
            return View("Locations/Locations", mr.GetLocationItems());
        }

        public ActionResult EditLocation(Location location)
        {
            return View("Locations/EditLocation", location);
        }

        [HttpPost]
        public ActionResult EditLocation(Location location, int id)
        {
            mr.DeleteLocationItem(mr.GetLocationItem(location.Id));
            mr.SaveNewLocation(location);
            return View("Locations/Locations", mr.GetLocationItems());
        }

        public ActionResult DeleteLocation(Location location)
        {
            mr.DeleteLocationItem(location);
            return View("Locations/Locations", mr.GetLocationItems());
        }

        public ActionResult Pages()
        {
            return View("Pages/Pages", mr.GetPages());
        }

        public ActionResult EditPage(Page page)
        {
            return View("Pages/EditPage", page);
        }

        [HttpPost]
        public ActionResult EditPage()
        {
            return View("Pages/Pages", mr.GetPages());
        }

        public ActionResult CreatePage()
        {
            return View("Pages/CreatePage");
        }

        [HttpPost]
        public ActionResult CreatePage(Page page)
        {
            mr.SaveNewPage(page);
            return View("Pages/pages", mr.GetPages());
        }

        public ActionResult DeletePage(Page page)
        {
            mr.DeletePage(page);
            return View("Pages/pages", mr.GetPages());
        }
<<<<<<< HEAD
        public ActionResult Movies()
        {
            return View("Movies/Movies", mr.GetMovies());
        }
        [HttpGet]
        public ActionResult AddMovies()
        {
            return View("Movies/AddMovies");
        }
        [HttpPost]
        public ActionResult Addmovies(Movy movie)
        {

            mr.SaveNewMovie(movie);
            return View("Movies/Movies", mr.GetMovies());

        }
        public ActionResult EditMovie(Movy movie)
        {
            return View("Movies/EditMovie", movie);
        }

        [HttpPost]
        public ActionResult EditMovie()
        {
            return View("Movies/Movies", mr.GetMovies());
        }

        public ActionResult DeleteMovie(Movy movies)
        {
            mr.DeleteMovies(movies);
            return View("Movies/Movies", mr.GetMovies());
=======

        public ActionResult Highlights()
        {
            return View("Highlights/Highlights", mr.GetHighlights());
        }

        public ActionResult AddHighlight()
        {
            return View("Highlights/AddHighlight");
        }

        [HttpPost]
        public ActionResult AddHighlight(Highlight highlight)
        {
            mr.SaveHighlight(highlight);
            return View("Highlights/Highlights", mr.GetHighlights());
        }

        public ActionResult DeleteHighlight(Highlight highlight)
        {
            mr.DeleteHighlight(highlight);
            return View("Highlights/Highlights", mr.GetHighlights());
        }

        public ActionResult EditHighlight(Highlight highlight)
        {
            return View("Highlights/EditHighlight", highlight);
        }

        [HttpPost]
        public ActionResult EditHighlight(Highlight highlight, int id)
        {
            mr.DeleteHighlight(mr.GetHighlight(highlight.Id));
            mr.SaveHighlight(highlight);
            return View("Highlights/Highlights", mr.GetHighlights());
>>>>>>> refs/remotes/origin/Jeroen
        }
    }
}