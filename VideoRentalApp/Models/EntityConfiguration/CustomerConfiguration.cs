using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Models.EntityConfiguration
{
    public class CustomerConfiguration:EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(c => c.BirthDate)
                .IsOptional();
        }
    }
}