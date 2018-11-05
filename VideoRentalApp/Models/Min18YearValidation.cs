using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalAPP.Models;

namespace VideoRentalApp.Models
{
    public class Min18YearValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == MemberShipType.UnKnown || customer.MemberShipTypeId == MemberShipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer Should Be 18 Year Old for The Membership");
        }
    }
}