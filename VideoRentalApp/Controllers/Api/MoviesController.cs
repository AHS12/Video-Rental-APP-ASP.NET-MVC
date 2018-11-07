using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VideoRentalApp.Dtos;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }

        //GET api/movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMove(MovieDto aMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(aMovieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            aMovieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), aMovieDto);
        }

        //PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto aMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.Find(id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(aMovieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.Find(Id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}