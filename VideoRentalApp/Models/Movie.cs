using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalAPP.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Movie Name")]
        public string Name { get; set; }

       [Display(Name = "Number of Stock")]
        [Required(ErrorMessage = "Provide Stock Number")]
        [Range(minimum:1,maximum:500)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Invalid number")]
        public int NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Provide Release Date")]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Select Genre")]
        public byte GenreId { get; set; }

    }
}