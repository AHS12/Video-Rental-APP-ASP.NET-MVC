using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;
using VideoRentalApp.ViewModels;
using VideoRentalAPP.ViewModels;

namespace VideoRentalAPP.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                //need it to populate ID or Get ModalState Error
                //Movie = new Movie(),
                //Now Using ViewModel with nullable ID To Avoid It
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    //Movie = new Movie(), We cant Pass This anymore so using Constructor of viewModel for Populate Field
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            // ViewBag.Message = aMovieManager.Save(movie);
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Find(movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
//                Id = movie.Id,
//                Name = movie.Name,
//                ReleaseDate = movie.ReleaseDate,
//                GenreId = movie.GenreId,
//                NumberInStock = movie.NumberInStock,
                //We Dont Need Them CUZ we ar going to use constructor
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }


        // GET: Movies
        public ViewResult Index()
        {
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Index");
            }

            return View("ReadOnlyIndex");
        }

//        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}