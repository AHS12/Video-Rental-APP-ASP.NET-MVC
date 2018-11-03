using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentalApp.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}