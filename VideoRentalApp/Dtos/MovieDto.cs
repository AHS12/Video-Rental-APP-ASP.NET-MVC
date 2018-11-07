using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 500)]
        [RegularExpression("([1-9][0-9]*)")]
        public int NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}