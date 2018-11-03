using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Managers;
using VideoRentalAPP.Models;
using VideoRentalAPP.Models.ViewModels;

namespace VideoRentalAPP.Controllers
{
    public class MovieController : Controller
    {

        private MovieManager aMovieManager;

        public MovieController()
        {
            aMovieManager = new MovieManager();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = aMovieManager.GetAllMoviesWithGenre();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            return View();
        }


//        public ActionResult Random()
//        {
//            Movie aMovie2 = new Movie()
//            {
//                Id = 2,
//                Name = "Zootopia"
//            };
//
//            var Customers = new List<Customer>()
//            {
//                new Customer(){Name = "Customer 1"},
//                new Customer(){Name = "Customer 2"}
//            };
////            ViewBag.RandMovie = aMovie2;
//
//            var viewModel = new RandomMovieViewModel()
//            {
//                Movie = aMovie2,
//                Customers = Customers
//            };
//            return View(viewModel);
//        }

//        [Route("movie/released/{year}/{month}")]
//        public ActionResult Release(int year, int month)
//        {
//            return Content(year + " " + month);
//        }
    }
}