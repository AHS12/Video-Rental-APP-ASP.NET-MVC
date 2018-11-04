using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
    }
}