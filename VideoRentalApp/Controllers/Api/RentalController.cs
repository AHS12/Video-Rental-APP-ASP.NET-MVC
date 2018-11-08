using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApp.Dtos;
using VideoRentalApp.Models;

namespace VideoRentalApp.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto aRentalDto)
        {
            if (aRentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids Have been Given!");
            }
            var customer = _context.Customers.Find(aRentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer Id is Invalid");
            }

            //SELECT * FROM Movies WHERE Id IN(1,2,3)
            var movies = _context.Movies.Where(m => aRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != aRentalDto.MovieIds.Count)
            {
                return BadRequest("One or more Movie Ids are Invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is Not Available!");
                }
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();


            return Ok();
        }
    }
}