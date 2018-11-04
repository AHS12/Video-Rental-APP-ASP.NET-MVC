using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Managers;
using VideoRentalAPP.Models;
using VideoRentalApp.ViewModels;
using VideoRentalAPP.ViewModels;

namespace VideoRentalAPP.Controllers
{
    public class MovieController : Controller
    {
        private MovieManager aMovieManager;

        public MovieController()
        {
            aMovieManager = new MovieManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = aMovieManager.GetAllGenres()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            ViewBag.Message = aMovieManager.Save(viewModel.Movie);

            viewModel.Genres = aMovieManager.GetAllGenres();
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = aMovieManager.GerMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = aMovieManager.GetAllGenres()
            };
            return View("MovieForm", viewModel);
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movies = aMovieManager.GetAllMoviesWithGenre();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = aMovieManager.GetMovieDetailsById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}