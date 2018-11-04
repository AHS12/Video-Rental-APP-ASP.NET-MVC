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

        [Required(ErrorMessage = "Provide Name!")]
        [StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }
        [Required] public byte MemberShipTypeId { get; set; }
    }
}