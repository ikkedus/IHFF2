using System;
using IHFF.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF.Controllers
{
    public class MovieInfoController : Controller
    {
        private MovieInfoRepository repo = new MovieInfoRepository();
        // GET: MovieInfo
        public ActionResult Index()
        {
            return View(repo.getInfoMovies());
        }
    }
}