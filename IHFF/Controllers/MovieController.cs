using IHFF.Models;
using IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class MovieController : Controller
    {
        private MoviesRepository repo = new MoviesRepository();
        // GET: Movie
        public ActionResult Index()
        {
            return View(repo.getMovies());
        }
    }


}