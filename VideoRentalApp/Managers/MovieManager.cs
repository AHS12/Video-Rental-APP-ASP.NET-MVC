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


        public string Save(Movie aMovie)
        {
            if (aMovie.Id == 0)
            {
                aMovie.DateAdded = DateTime.Now;
                _context.Movies.Add(aMovie);
                return _context.SaveChanges() > 0 ? "Saved!" : "Failed!";
            }
            else
            {
                var movieInDb = _context.Movies.Find(aMovie.Id);
                movieInDb.Name = aMovie.Name;
                movieInDb.Genre = aMovie.Genre;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.ReleaseDate = aMovie.ReleaseDate;
                movieInDb.NumberInStock = aMovie.NumberInStock;

                return _context.SaveChanges() > 0 ? "Updated!" : "Failed!";
            }
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            var genres = _context.Genres.ToList();
            return genres;
        }

        public List<Movie> GetAllMoviesWithGenre()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return movies;
        }

        public Movie GetMovieDetailsById(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return movie;
        }

        public Movie GerMovieById(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie;
        }
    }
}