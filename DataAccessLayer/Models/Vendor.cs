using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }


        public string VendorName { get; set; }


        public decimal VendorBusinessNumber { get; set; }


        public int VendorOrgGroupId { get; set; }


        public decimal ContactNumber { get; set; }
    }
}
