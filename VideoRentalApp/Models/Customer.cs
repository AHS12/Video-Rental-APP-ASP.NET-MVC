using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;

namespace VideoRentalAPP.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Name!")]
        [StringLength(255)]
        public string Name { get; set; }
        //Note: BusinessLogic: Customer must be 18 year or older for other membership type ratherThen PayAsYouGo
        [DataType(DataType.Date)]
        [Min18YearValidation]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }
        [Required(ErrorMessage = "Please Select a Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }
}