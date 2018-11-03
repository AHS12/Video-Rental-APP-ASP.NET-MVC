using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Managers
{
    public class MovieManager
    {
        private ApplicationDbContext _context;

        public MovieManager()
        {
            _context = new ApplicationDbContext();
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }

        public List<Movie> GetAllMoviesWithGenre()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return movies;
        }

        public Movie GetMovieDetailsById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return movie;
        }
    }
}