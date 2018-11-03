using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalAPP.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
  
    }
}