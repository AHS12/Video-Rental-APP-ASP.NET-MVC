using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalAPP.ViewModels
{
    public class MovieFormViewModel
    {
        //   public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Provide Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Number of Stock")]
        [Required(ErrorMessage = "Provide Stock Number")]
        [Range(minimum: 1, maximum: 500)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Invalid number")]
        public int? NumberInStock { get; set; }


        [Required(ErrorMessage = "Provide Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Select a Genre")]
        public byte? GenreId { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}