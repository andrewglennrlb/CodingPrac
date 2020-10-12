using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Address
    {
        [Key]
        public Int64 AddressId { get; set; }

        public String Line1 { get; set; }

        public String Line2 { get; set; }

        public String Line3 { get; set; }

        public Int64 ProvinceId { get; set; }

        public String CountryISOId { get; set; }

        public Int64 PostCodeId { get; set; }

        public Decimal Longitude { get; set; }

        public Decimal Latitude { get; set; }

        public String TownSuburb { get; set; }
    }
}
