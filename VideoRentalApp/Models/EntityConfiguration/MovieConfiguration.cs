using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Models.EntityConfiguration
{
    public class MovieConfiguration:EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}