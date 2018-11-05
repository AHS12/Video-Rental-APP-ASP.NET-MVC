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

        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}