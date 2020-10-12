using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Currency
    {
        [Key]
        public Int64 Id { get; set; }


        public String IsoCode { get; set; }


        public String CurrencyName { get; set; }


        public String Symbol { get; set; }
    }
}
